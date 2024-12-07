using SIS.Model;

namespace SIS.Service.Student
{
    public interface IStudentService
    {
        Task<int> Save(StudentDto Dto);
        Task<int> Update(StudentDto Dto);
        Task<List<StudentDto>> ListAll(StudentDto Dto);
        Task<StudentDto> Get(int Id);
        Task<int> Delete(int Id);
    }
}
