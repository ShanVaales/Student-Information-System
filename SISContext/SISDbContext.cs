using Microsoft.EntityFrameworkCore;
using SIS.Model;

namespace SIS.SISContext
{
    public class SISDbContext : DbContext
    {
        public SISDbContext(DbContextOptions<SISDbContext> options) : base(options) { }
        public DbSet<StudentDto> Students { get; set; }
        public DbSet<StudentMedicalDetails> StudentMedicalDetails { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubjectCode> TeachersSubjectCode { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<AspUser> AspUsers { get; set; }
    }
}
