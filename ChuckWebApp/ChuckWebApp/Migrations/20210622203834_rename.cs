using Microsoft.EntityFrameworkCore.Migrations;

namespace ChuckWebApp.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDone",
                table: "Todo",
                newName: "IsDone");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Todo",
                newName: "DueDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "Todo",
                newName: "isDone");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Todo",
                newName: "dueDate");
        }
    }
}
