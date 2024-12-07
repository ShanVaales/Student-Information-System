using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class Teacher : TimeEntity
    {
        public string FistName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string EmergencyContactNo { get; set; }

        //Professional Details 
        public string EmployeeID { get; set; }
        public int Designation { get; set; }
        public int Department { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int Qualification { get; set; }
        public int Experience { get; set; }
    }
}
