using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using titova_yulia_kt_31_21.Database;
using titova_yulia_kt_31_21.Interfaces.ExamInterfaces;
using titova_yulia_kt_31_21.Interfaces.TestInterfaces;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_yurevna_kt_31_21.Tests
{
    public class StudentPassedTestTests
    {
        public readonly DbContextOptions<StudentPerfomanceDbContext> _dbContextOptions;

        public StudentPassedTestTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentPerfomanceDbContext>()
            .UseInMemoryDatabase(databaseName: "StudentsPerfomance")
            .Options;
        }

        [Fact]
        public async Task PostTestResultStudentsAsync_True()
        {
            // Arrange
            var ctx = new StudentPerfomanceDbContext(_dbContextOptions);
            var testService = new TestService(ctx);

            var subjects = new List<Subject>
            {
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
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            await testService.AddTestAsync(1, 1, true, CancellationToken.None);
            var testResult = await testService.GetTestsdAsync(CancellationToken.None);

            // Assert
            Assert.True(testResult[0].IsPassed);
        }

        [Fact]
        public async Task EditTestResultStudentsAsync_False()
        {
            // Arrange
            var ctx = new StudentPerfomanceDbContext(_dbContextOptions);
            var testService = new TestService(ctx);

            // Act
            await testService.EditTestAsync(1, false, CancellationToken.None);
            var testResult = await testService.GetTestsdAsync(CancellationToken.None);

            // Assert
            Assert.False(testResult[0].IsPassed);
        }
    }
}
