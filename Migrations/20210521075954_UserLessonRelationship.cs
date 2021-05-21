using Microsoft.EntityFrameworkCore.Migrations;

namespace aMuseAPI.Migrations
{
    public partial class UserLessonRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "authorid",
                table: "lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lessons_authorid",
                table: "lessons",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_users_authorid",
                table: "lessons",
                column: "authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_users_authorid",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_lessons_authorid",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "authorid",
                table: "lessons");
        }
    }
}
