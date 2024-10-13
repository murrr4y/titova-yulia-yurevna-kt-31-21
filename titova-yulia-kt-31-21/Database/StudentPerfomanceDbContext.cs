using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Database.Configurations;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_kt_31_21.Database
{
    public class StudentPerfomanceDbContext : DbContext
    {
        //Таблички-лисички
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Конфигурашки-мурашки
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public StudentPerfomanceDbContext(DbContextOptions<StudentPerfomanceDbContext> options) : base(options) 
        { 
        }
    }
}
