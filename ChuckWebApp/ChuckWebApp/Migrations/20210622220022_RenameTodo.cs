using Microsoft.EntityFrameworkCore.Migrations;

namespace ChuckWebApp.Migrations
{
    public partial class RenameTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Todo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
