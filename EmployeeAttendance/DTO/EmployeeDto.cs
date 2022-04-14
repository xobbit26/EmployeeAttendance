namespace EmployeeAttendance.DTO;

public record EmployeeDto(
        long Id,
        string Name,
        string Surname,
        string Birthday,
        string HiringDate,
        string Position,
        string Department,
        bool IsActive
    );
