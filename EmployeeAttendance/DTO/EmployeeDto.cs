namespace EmployeeAttendance.Dto;

public class EmployeeDto
{
    public long Id { get; init; }

    public string Name { get; init; } = null!;

    public string Surname { get; init; } = null!;

    public string Birthday { get; init; } = null!;

    public string HiringDate { get; init; } = null!;

    public string Position { get; init; } = null!;

    public string Department { get; init; } = null!;

    public bool IsActive { get; init; }
}
