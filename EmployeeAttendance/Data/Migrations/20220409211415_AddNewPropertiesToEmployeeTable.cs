using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAttendance.Migrations
{
    public partial class AddNewPropertiesToEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "employee");

            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "employee",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "department",
                table: "employee");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
