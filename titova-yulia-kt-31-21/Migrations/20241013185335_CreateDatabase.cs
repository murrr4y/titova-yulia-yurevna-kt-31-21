using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace titova_yulia_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "ID группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "ID предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subject_name = table.Column<string>(type: "varchar", maxLength: 250, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    exam_id = table.Column<int>(type: "integer", nullable: false, comment: "ID экзамена")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "ID студента"),
                    f_subject_id = table.Column<int>(type: "int4", nullable: false, comment: "ID предмета"),
                    c_mark = table.Column<int>(type: "int4", nullable: false, comment: "Оценка")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam_exam_id", x => x.exam_id);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.f_subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "ID студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int4", nullable: false, comment: "ID группы"),
                    f_exam_id = table.Column<int>(type: "int4", nullable: false, comment: "ID оценок за экзамены"),
                    f_test_id = table.Column<int>(type: "int4", nullable: false, comment: "ID зачетов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_exam_id",
                        column: x => x.f_exam_id,
                        principalTable: "exam",
                        principalColumn: "exam_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "integer", nullable: false, comment: "ID зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "ID студента"),
                    f_subject_id = table.Column<int>(type: "int4", nullable: false, comment: "ID предмета"),
                    c_is_passed = table.Column<bool>(type: "bool", nullable: false, comment: "Зачет сдан")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_test_test_id", x => x.test_id);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.f_student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.f_subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_exam_fk_f_student_id",
                table: "exam",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "idx_exam_fk_f_subject_id",
                table: "exam",
                column: "f_subject_id");

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_exam_id",
                table: "student",
                column: "f_exam_id");

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_group_id",
                table: "student",
                column: "f_group_id");

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_test_id",
                table: "student",
                column: "f_test_id");

            migrationBuilder.CreateIndex(
                name: "idx_test_fk_f_student_id",
                table: "test",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "idx_test_fk_f_subject_id",
                table: "test",
                column: "f_subject_id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_student_id",
                table: "exam",
                column: "f_student_id",
                principalTable: "student",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_test_id",
                table: "student",
                column: "f_test_id",
                principalTable: "test",
                principalColumn: "test_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_student_id",
                table: "exam");

            migrationBuilder.DropForeignKey(
                name: "fk_f_student_id",
                table: "test");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "test");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
