using Microsoft.EntityFrameworkCore.Migrations;

namespace aMuseAPI.Migrations
{
    public partial class ChangeAuthorToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_users_authorid",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "authorid",
                table: "lessons",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_authorid",
                table: "lessons",
                newName: "IX_lessons_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_users_userid",
                table: "lessons",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_users_userid",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "lessons",
                newName: "authorid");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_userid",
                table: "lessons",
                newName: "IX_lessons_authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_users_authorid",
                table: "lessons",
                column: "authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
