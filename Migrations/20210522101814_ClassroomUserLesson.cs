using Microsoft.EntityFrameworkCore.Migrations;

namespace aMuseAPI.Migrations
{
    public partial class ClassroomUserLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_classrooms_Classroomid",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "Classroomid",
                table: "lessons",
                newName: "classroomid");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_Classroomid",
                table: "lessons",
                newName: "IX_lessons_classroomid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_classrooms_classroomid",
                table: "lessons",
                column: "classroomid",
                principalTable: "classrooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_classrooms_classroomid",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "classroomid",
                table: "lessons",
                newName: "Classroomid");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_classroomid",
                table: "lessons",
                newName: "IX_lessons_Classroomid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_classrooms_Classroomid",
                table: "lessons",
                column: "Classroomid",
                principalTable: "classrooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
