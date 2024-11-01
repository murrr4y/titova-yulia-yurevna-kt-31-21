using titova_yulia_kt_31_21.Database;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Models;


namespace titova_yulia_kt_31_21.Interfaces.ExamInterfaces
{
    public interface IExamService
    {
        public Task<Exam[]> GetExamsdAsync(CancellationToken cancellationToken);
        public Task AddExamAsync(int stidentId, int subjectId, int mark, CancellationToken cancellationToken);
        public Task EditExamAsync(int examId, int mark, CancellationToken cancellationToken = default);
    }
    public class ExamService : IExamService
    {
        private readonly StudentPerfomanceDbContext _dbContext;
        public ExamService(StudentPerfomanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Exam[]> GetExamsdAsync(CancellationToken cancellationToken = default)
        {
            var exams = _dbContext.Set<Exam>().ToArrayAsync(cancellationToken);

            return exams;
        }
        public async Task AddExamAsync(int studentId, int subjectId, int mark, CancellationToken cancellationToken = default)
        {
            var newExam = new Exam
            {
                StudentId = studentId,
                SubjectId = subjectId,
                Mark = mark,
            };

            _dbContext.Exams.Add(newExam);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditExamAsync(int examId, int mark, CancellationToken cancellationToken = default)
        {
            var exam = await _dbContext.Set<Exam>().FindAsync(examId);
            if (exam != null)
            {
                exam.Mark = mark;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Запись с id {examId} не найдена.");
            }
        }
    }
}
