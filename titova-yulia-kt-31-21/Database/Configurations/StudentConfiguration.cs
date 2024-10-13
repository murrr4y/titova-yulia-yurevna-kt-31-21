using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using titova_yulia_kt_31_21.Models;
using titova_yulia_kt_31_21.Database.Helpers;

namespace titova_yulia_kt_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.StudentId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("ID студента");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID группы");

            builder.Property(p => p.ExamId)
                .IsRequired()
                .HasColumnName("f_exam_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID оценок за экзамены");

            builder.Property(p => p.TestId)
                .IsRequired()
                .HasColumnName("f_test_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID зачетов");

            // Настройка таблицы и связей
            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Exam)
                .WithMany()
                .HasForeignKey(p => p.ExamId)
                .HasConstraintName("fk_f_exam_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Test)
                .WithMany()
                .HasForeignKey(p => p.TestId)
                .HasConstraintName("fk_f_test_id")
                .OnDelete(DeleteBehavior.Cascade);

            // Индексы
            builder.HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");
            builder.HasIndex(p => p.ExamId, $"idx_{TableName}_fk_f_exam_id");
            builder.HasIndex(p => p.TestId, $"idx_{TableName}_fk_f_test_id");

            // Автоподгрузка связанных сущностей
            builder.Navigation(p => p.Group).AutoInclude();
            builder.Navigation(p => p.Exam).AutoInclude();
            builder.Navigation(p => p.Test).AutoInclude();
        }
    }
}
