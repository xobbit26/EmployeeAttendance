using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRecorder.Migrations
{
    public partial class AddIsActiveColumnToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "employees");
        }
    }
}
