using titova_yulia_kt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Models;


namespace titova_yulia_kt_31_21.Interfaces.TestInterfaces
{
    public interface ITestService
    {
        public Task<Test[]> GetTestsdAsync(CancellationToken cancellationToken);
        public Task AddTestAsync(int stidentId, int subjectId, bool isPassed, CancellationToken cancellationToken);
        public Task EditTestAsync(int testId, bool isPassed, CancellationToken cancellationToken = default);
        public Task DeleteTestpAsync(int testId, CancellationToken cancellationToken = default);
    }
    public class TestService : ITestService
    {
        private readonly StudentPerfomanceDbContext _dbContext;
        public TestService(StudentPerfomanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Test[]> GetTestsdAsync(CancellationToken cancellationToken = default)
        {
            var tests = _dbContext.Set<Test>().ToArrayAsync(cancellationToken);

            return tests;
        }
        public async Task AddTestAsync(int studentId, int subjectId, bool isPassed, CancellationToken cancellationToken = default)
        {
            var newTest = new Test
            {
                StudentId = studentId,
                SubjectId = subjectId,
                IsPassed = isPassed,
            };

            _dbContext.Tests.Add(newTest);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditTestAsync(int testId, bool isPassed, CancellationToken cancellationToken = default)
        {
            var test = await _dbContext.Set<Test>().FindAsync(testId);
            if (test != null)
            {
                test.IsPassed = isPassed;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Запись с id {testId} не найдена.");
            }
        }
        public async Task DeleteTestpAsync(int testId, CancellationToken cancellationToken = default)
        {
            var test = await _dbContext.Set<Test>().FindAsync(testId);
            if (test != null)
            {
                _dbContext.Tests.Remove(test);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Запись с id {testId} не найдена.");
            }
        }
    }
}
