﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using titova_yulia_kt_31_21.Database.Helpers;
using titova_yulia_kt_31_21.Models;

namespace titova_yulia_kt_31_21.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "test";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.TestId)
                .HasName($"pk_{TableName}_test_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.TestId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.TestId)
                .HasColumnName("test_id")
                .HasComment("ID зачета");

            builder.Property(p => p.IsPassed)
                .IsRequired()
                .HasColumnName("c_is_passed")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Зачет сдан");

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("f_student_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID студента");

            builder.Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("f_subject_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID предмета");


            // Настройка таблицы и связей
            builder.ToTable(TableName)
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName("fk_f_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Subject)
                .WithMany()
                .HasForeignKey(p => p.SubjectId)
                .HasConstraintName("fk_f_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            // Индексы
            builder.HasIndex(p => p.StudentId, $"idx_{TableName}_fk_f_student_id");
            builder.HasIndex(p => p.SubjectId, $"idx_{TableName}_fk_f_subject_id");

            // Автоподгрузка связанных сущностей
            builder.Navigation(p => p.Student).AutoInclude();
            builder.Navigation(p => p.Subject).AutoInclude();
        }
    }
}