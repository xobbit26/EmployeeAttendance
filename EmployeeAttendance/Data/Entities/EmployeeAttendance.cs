using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Data.Entities;

[Table("employee_attendance")]
public class EmployeeAttendance
{
    public long Id { get; set; }
    public DateTime EnterDateTime { get; set; }
    public DateTime LeaveDateTime { get; set; }
    public Employee Employee { get; set; } = null!;
}