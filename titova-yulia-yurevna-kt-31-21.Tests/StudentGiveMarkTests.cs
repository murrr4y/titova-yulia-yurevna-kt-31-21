using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using titova_yulia_kt_31_21.Database;
using titova_yulia_kt_31_21.Interfaces.ExamInterfaces;
using titova_yulia_kt_31_21.Interfaces.StudentInterfaces;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_yurevna_kt_31_21.Tests
{
    public class StudentGiveMarkTests
    {
        public readonly DbContextOptions<StudentPerfomanceDbContext> _dbContextOptions;

        public StudentGiveMarkTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentPerfomanceDbContext>()
            .UseInMemoryDatabase(databaseName: "StudentsPerfomance")
            .Options;
        }

        [Fact]
        public async Task PostMarkStudentAsync_5()
        {
            // Arrange
            var ctx = new StudentPerfomanceDbContext(_dbContextOptions);
            var examService = new ExamService(ctx);

            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "Зельеварение"
                },
                new Subject
                {
                    SubjectName = "Создание багов"
                },
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);

            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            await examService.AddExamAsync(1, 1, 5,  CancellationToken.None);
            var examResult = await examService.GetExamsdAsync(CancellationToken.None);

            // Assert
            Assert.Equal(5, examResult[0].Mark);
        }

        [Fact]
        public async Task EditMarkStudentAsync_3()
        {
            // Arrange
            var ctx = new StudentPerfomanceDbContext(_dbContextOptions);
            var examService = new ExamService(ctx);

            // Act
            await examService.EditExamAsync(1, 3, CancellationToken.None);
            var examResult = await examService.GetExamsdAsync(CancellationToken.None);

            // Assert
            Assert.Equal(3, examResult[0].Mark);
        }
    }
}
