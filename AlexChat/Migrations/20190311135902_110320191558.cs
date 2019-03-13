using Microsoft.EntityFrameworkCore.Migrations;

namespace AlexChat.Migrations
{
    public partial class _110320191558 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                column: "Id",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
