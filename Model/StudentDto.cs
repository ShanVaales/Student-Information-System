using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class StudentDto : TimeEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public string? email { get; set; }
        public string? ParentName { get; set; }
        public string? ParentContactNo { get; set; }
        public string? ParentContactEmail { get; set; }

        //ACADAMIC INFORMATION
        public int Class { get; set; }
        public int Section { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string? PreSchool { get; set; }
    }
}
