using EmployeeAttendance.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Data.Entities;

[Table("employee")]
public class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public DateOnly HiringDate { get; set; }

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public bool IsActive { get; set; }

    public List<EmployeeAttendance>? EmployeeAttendances { get; set; } = new();
}
