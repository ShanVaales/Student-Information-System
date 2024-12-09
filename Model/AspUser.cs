using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class AspUser : TimeEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? RecoveryMail { get; set; }
        public bool IsTwoFactor { get; set; }
    }

    public class RegisterUserDto
    {
        public string FirstName {  set; get; } = string.Empty;
        public string LastName { set; get; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsTwoFactor { get; set; }

    }
}
