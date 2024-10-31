using titova_yulia_kt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Interfaces.TestInterfaces;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_kt_31_21.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsdAsync(CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private readonly StudentPerfomanceDbContext _dbContext;
        public StudentService(StudentPerfomanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsdAsync(CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
