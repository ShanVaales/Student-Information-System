﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SIS.Model;
using SIS.Service.Account;
using SIS.SISContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly SISDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountsController(IAccountsService accountsService, SISDbContext context_,IConfiguration configuration_)
        {
            _context = context_;
            _configuration = configuration_;
            _accountsService = accountsService;
        }
        //public static AspUser Data = new AspUser();
        //[HttpPost("Register")]
        //public async Task<ActionResult<AspUser>> RegisterUser([FromBody] RegisterUserDto User)
        //{

        //    PasswordHashing(User.Password, null, null);
        //    Data.Username = User.Username;
        //    //Data.PasswordHash = PasswordHash;
        //    //Data.PasswordSalt = PasswordSalt;
        //    return Ok(Data);
        //}

        //public void PasswordHashing(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        //{
        //    var hmac = new HMACSHA512();
        //    PasswordSalt = hmac.Key;
        //    PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
        //}


        public static AspUser Data = new AspUser();

        [HttpPost("Register")]
        public async Task<ActionResult<AspUser>> RegisterUser([FromBody] RegisterUserDto user)
        {
            if(_context.AspUsers.Any(x => x.Username == user.Username)){
                return BadRequest("User Already Exists");
            }
            // Check if the password is null or empty
            if (string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Password is required.");

            // Generate password hash and salt
            PasswordHashing(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Populate the Data object
            Data.Username = user.Username;
            Data.FirstName = user.FirstName;
            Data.LastName = user.LastName;
            Data.PasswordHash = passwordHash;
            Data.PasswordSalt = passwordSalt;
            Data.UserId = Guid.NewGuid().ToString();
            Data.IsTwoFactor = user.IsTwoFactor;
            var result = _accountsService.SaveUser(Data);
            return Ok(Data);
        }

        [HttpPost("Login")]

        public ActionResult<string> Login (string username , string password)
        {
            var checkusername = _accountsService.GetByIdUserName(username).Result;
            if(checkusername != null)
            {
                var r = VerifyPassword(password,checkusername.PasswordHash, checkusername.PasswordSalt);
                if(r == false)
                {
                    return BadRequest("Invalid Password");
                }
                else
                {
                    string Token = GenerateToken(checkusername);
                    return Ok(Token);
                    return Ok(checkusername);
                }
            }
            else
            {
                return BadRequest("No User Found");
            }
        }

        private void PasswordHashing(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(HMAC hMAC = new HMACSHA512(passwordSalt))
            {
                var computedHash = hMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string GenerateToken (AspUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        

        

    }
}
