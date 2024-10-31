using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Database.Configurations;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_kt_31_21.Database
{
    public class StudentPerfomanceDbContext : DbContext
    {
        //Таблички-лисички
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Конфигурашки-мурашки
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public StudentPerfomanceDbContext(DbContextOptions<StudentPerfomanceDbContext> options) : base(options) { }
    }
}
