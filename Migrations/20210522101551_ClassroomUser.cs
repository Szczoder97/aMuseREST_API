using Microsoft.EntityFrameworkCore.Migrations;

namespace aMuseAPI.Migrations
{
    public partial class ClassroomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classrooms_users_Userid",
                table: "classrooms");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "classrooms",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_classrooms_Userid",
                table: "classrooms",
                newName: "IX_classrooms_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_classrooms_users_userid",
                table: "classrooms",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classrooms_users_userid",
                table: "classrooms");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "classrooms",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_classrooms_userid",
                table: "classrooms",
                newName: "IX_classrooms_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_classrooms_users_Userid",
                table: "classrooms",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
