using SIS.Model;

namespace SIS.Service.Student
{
    public class StudentService : IStudentService
    {
        public Task<int> Save(StudentDto Dto)
        {
            return Task.FromResult(0);
        }
        public Task<int> Delete(int Id)
        {
            return Task.FromResult(0);
        }
        public Task<int> Update(StudentDto Dto)
        {
            return Task.FromResult(0);
        }
        public Task<List<StudentDto>> ListAll(StudentDto Dto)
        {
            List<StudentDto> ReturnData = new List<StudentDto>();
            return Task.FromResult(ReturnData);
        }
        public Task<StudentDto> Get(int Id)
        {
            StudentDto studentDto = new StudentDto();
            return Task.FromResult(studentDto);
        }
    }
}
