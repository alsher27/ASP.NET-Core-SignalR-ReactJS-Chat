using Microsoft.EntityFrameworkCore.Migrations;

namespace AlexChat.Migrations
{
    public partial class _110320191525 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Messages",
                newName: "dateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Messages",
                newName: "DateTime");
        }
    }
}
