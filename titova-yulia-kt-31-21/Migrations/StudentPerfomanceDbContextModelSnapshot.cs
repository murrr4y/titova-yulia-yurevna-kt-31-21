﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using titova_yulia_kt_31_21.Database;

#nullable disable

namespace titova_yulia_kt_31_21.Migrations
{
    [DbContext(typeof(StudentPerfomanceDbContext))]
    partial class StudentPerfomanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("exam_id")
                        .HasComment("ID экзамена");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExamId"));

                    b.Property<int>("Mark")
                        .HasColumnType("int4")
                        .HasColumnName("c_mark")
                        .HasComment("Оценка");

                    b.Property<int>("StudentId")
                        .HasColumnType("int4")
                        .HasColumnName("f_student_id")
                        .HasComment("ID студента");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int4")
                        .HasColumnName("f_subject_id")
                        .HasComment("ID предмета");

                    b.HasKey("ExamId")
                        .HasName("pk_exam_exam_id");

                    b.HasIndex(new[] { "StudentId" }, "idx_exam_fk_f_student_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_exam_fk_f_subject_id");

                    b.ToTable("exam", (string)null);
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id")
                        .HasComment("ID группы");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_group_name")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_group_group_id");

                    b.ToTable("group", (string)null);
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("student_id")
                        .HasComment("ID студента");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int4")
                        .HasColumnName("f_exam_id")
                        .HasComment("ID оценок за экзамены");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<int>("GroupId")
                        .HasColumnType("int4")
                        .HasColumnName("f_group_id")
                        .HasComment("ID группы");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.Property<int>("TestId")
                        .HasColumnType("int4")
                        .HasColumnName("f_test_id")
                        .HasComment("ID зачетов");

                    b.HasKey("StudentId")
                        .HasName("pk_student_student_id");

                    b.HasIndex(new[] { "ExamId" }, "idx_student_fk_f_exam_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_student_fk_f_group_id");

                    b.HasIndex(new[] { "TestId" }, "idx_student_fk_f_test_id");

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subject_id")
                        .HasComment("ID предмета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("c_subject_name")
                        .HasComment("Название предмета");

                    b.HasKey("SubjectId")
                        .HasName("pk_subject_subject_id");

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("test_id")
                        .HasComment("ID зачета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TestId"));

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bool")
                        .HasColumnName("c_is_passed")
                        .HasComment("Зачет сдан");

                    b.Property<int>("StudentId")
                        .HasColumnType("int4")
                        .HasColumnName("f_student_id")
                        .HasComment("ID студента");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int4")
                        .HasColumnName("f_subject_id")
                        .HasComment("ID предмета");

                    b.HasKey("TestId")
                        .HasName("pk_test_test_id");

                    b.HasIndex(new[] { "StudentId" }, "idx_test_fk_f_student_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_test_fk_f_subject_id");

                    b.ToTable("test", (string)null);
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Exam", b =>
                {
                    b.HasOne("titova_yulia_kt_31_21.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("titova_yulia_kt_31_21.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Student", b =>
                {
                    b.HasOne("titova_yulia_kt_31_21.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_exam_id");

                    b.HasOne("titova_yulia_kt_31_21.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.HasOne("titova_yulia_kt_31_21.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_test_id");

                    b.Navigation("Exam");

                    b.Navigation("Group");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("titova_yulia_kt_31_21.Models.Test", b =>
                {
                    b.HasOne("titova_yulia_kt_31_21.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("titova_yulia_kt_31_21.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
