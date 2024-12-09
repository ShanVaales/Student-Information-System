namespace SIS.Model
{
    public class Login
    {
        public DateTime Logintime { get; set; }
        public string? UserId { get; set; }
        public string IsValid { get; set; }
        public string? Token { get; set; }
    }
}
