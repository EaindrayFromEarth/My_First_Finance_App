using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_First_Finance_App.Migrations
{
    public partial class ExpenseTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SavingBalance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavingBalance",
                table: "Transactions");
        }
    }
}
