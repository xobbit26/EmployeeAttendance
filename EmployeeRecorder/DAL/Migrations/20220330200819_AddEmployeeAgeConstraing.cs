using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRecorder.Migrations
{
    public partial class AddEmployeeAgeConstraing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "ck_employee_age",
                table: "employee",
                sql: "age > 0 and age < 120");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_employee_age",
                table: "employee");
        }
    }
}
