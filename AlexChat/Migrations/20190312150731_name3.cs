using Microsoft.EntityFrameworkCore.Migrations;

namespace AlexChat.Migrations
{
    public partial class name3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_chatId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "chatId",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_chatId",
                table: "Messages",
                column: "chatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_chatId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "chatId",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Chats",
                column: "Id",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_chatId",
                table: "Messages",
                column: "chatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
