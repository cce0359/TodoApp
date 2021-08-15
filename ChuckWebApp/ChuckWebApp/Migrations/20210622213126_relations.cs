using Microsoft.EntityFrameworkCore.Migrations;

namespace ChuckWebApp.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_AspNetUsers_UserId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_UserId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "TodoUserID",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Todo",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChuckWebAppUserId",
                table: "Todo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_ChuckWebAppUserId",
                table: "Todo",
                column: "ChuckWebAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_AspNetUsers_ChuckWebAppUserId",
                table: "Todo",
                column: "ChuckWebAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_AspNetUsers_ChuckWebAppUserId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_ChuckWebAppUserId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "ChuckWebAppUserId",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Todo",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Todo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TodoUserID",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_UserId",
                table: "Todo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_AspNetUsers_UserId",
                table: "Todo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
