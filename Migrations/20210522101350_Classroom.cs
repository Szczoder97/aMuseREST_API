using Microsoft.EntityFrameworkCore.Migrations;

namespace aMuseAPI.Migrations
{
    public partial class Classroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classroomid",
                table: "lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classrooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_classrooms_users_Userid",
                        column: x => x.Userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lessons_Classroomid",
                table: "lessons",
                column: "Classroomid");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_Userid",
                table: "classrooms",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_classrooms_Classroomid",
                table: "lessons",
                column: "Classroomid",
                principalTable: "classrooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_classrooms_Classroomid",
                table: "lessons");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropIndex(
                name: "IX_lessons_Classroomid",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Classroomid",
                table: "lessons");
        }
    }
}
