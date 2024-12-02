using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class StudentMedicalDetails : TimeEntity
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int BloodGroup { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
    }
}
