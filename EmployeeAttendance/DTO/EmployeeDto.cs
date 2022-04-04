namespace EmployeeAttendance.Dto;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int Age { get; set; }
    public DateTime HiringDate { get; set; }
    public string Position { get; set; } = null!;
    public bool IsActive { get; set; }
}
