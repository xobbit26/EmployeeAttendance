using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Data.Entities;

[Table("employee")]
public class Employee
{
    public Employee(long id,
        string name,
        string surname,
        DateOnly birthday,
        DateOnly hiringDate,
        string position,
        string department,
        bool isActive,
        List<EmployeeAttendance>? employeeAttendances)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Birthday = birthday;
        HiringDate = hiringDate;
        Position = position;
        Department = department;
        IsActive = isActive;
        EmployeeAttendances = employeeAttendances;
    }

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