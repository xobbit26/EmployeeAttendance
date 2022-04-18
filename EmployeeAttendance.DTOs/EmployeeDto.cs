namespace EmployeeAttendance.DTOs;

public readonly record struct EmployeeDto(
    int Id,
    string Name,
    string Surname,
    string Birthday,
    string HiringDate,
    string Position,
    string Department,
    bool IsActive
);