using titova_yulia_kt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_kt_31_21.Interfaces.SubjectInterfaces
{
    public interface ISubjectService
    {
        public Task<Subject[]> GetSubjectsAsync(CancellationToken cancellationToken);
    }
    public class SubjectService : ISubjectService
    {
        private readonly StudentPerfomanceDbContext _dbContext;
        public SubjectService(StudentPerfomanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Subject[]> GetSubjectsAsync(CancellationToken cancellationToken = default)
        {
            var subjects = _dbContext.Set<Subject>().ToArrayAsync(cancellationToken);

            return subjects;
        }
    }
}
