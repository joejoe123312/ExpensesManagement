using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesManagement.Migrations
{
    public partial class AddedexpenseNameinexpensetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseName",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseName",
                table: "Expenses");
        }
    }
}
