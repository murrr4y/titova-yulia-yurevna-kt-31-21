using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace titova_yulia_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class FixStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_exam_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "fk_f_test_id",
                table: "student");

            migrationBuilder.DropIndex(
                name: "idx_student_fk_f_exam_id",
                table: "student");

            migrationBuilder.DropIndex(
                name: "idx_student_fk_f_test_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "f_exam_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "f_test_id",
                table: "student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "f_exam_id",
                table: "student",
                type: "int4",
                nullable: false,
                defaultValue: 0,
                comment: "ID оценок за экзамены");

            migrationBuilder.AddColumn<int>(
                name: "f_test_id",
                table: "student",
                type: "int4",
                nullable: false,
                defaultValue: 0,
                comment: "ID зачетов");

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_exam_id",
                table: "student",
                column: "f_exam_id");

            migrationBuilder.CreateIndex(
                name: "idx_student_fk_f_test_id",
                table: "student",
                column: "f_test_id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_exam_id",
                table: "student",
                column: "f_exam_id",
                principalTable: "exam",
                principalColumn: "exam_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_f_test_id",
                table: "student",
                column: "f_test_id",
                principalTable: "test",
                principalColumn: "test_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
