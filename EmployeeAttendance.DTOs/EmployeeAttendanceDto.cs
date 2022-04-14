namespace EmployeeAttendance.DTOs;

public record EmployeeAttendanceDto(
    DateTime EnterDateTime,
    DateTime LeaveDateTime
);
