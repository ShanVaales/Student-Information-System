using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class Principal : TimeEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string? EmergencyContact { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Qualification { get; set; }
        public int Experience { get; set; }
    }
}
