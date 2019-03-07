using Microsoft.EntityFrameworkCore.Migrations;

namespace AlexChat.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatIdId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ChatIdId",
                table: "Messages",
                newName: "chatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatIdId",
                table: "Messages",
                newName: "IX_Messages_chatId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Chats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_UserId",
                table: "Chats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Chats_Users_UserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_chatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "chatId",
                table: "Messages",
                newName: "ChatIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_chatId",
                table: "Messages",
                newName: "IX_Messages_ChatIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatIdId",
                table: "Messages",
                column: "ChatIdId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
