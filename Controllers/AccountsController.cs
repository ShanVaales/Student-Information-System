using Microsoft.AspNetCore.Mvc;
using SIS.Model;
using System.Security.Cryptography;

namespace SIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
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
            // Check if the password is null or empty
            if (string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Password is required.");

            // Generate password hash and salt
            PasswordHashing(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Populate the Data object
            Data.Username = user.Username;
            Data.PasswordHash = passwordHash;
            Data.PasswordSalt = passwordSalt;

            return Ok(Data);
        }

        private void PasswordHashing(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
