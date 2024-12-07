using SIS.Model.BaseModel;

namespace SIS.Model
{
    public class TeacherSubjectCode : TimeEntity
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
    }
}
