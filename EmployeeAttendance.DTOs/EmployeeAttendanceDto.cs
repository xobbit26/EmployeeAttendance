namespace EmployeeAttendance.DTOs;

public readonly record struct EmployeeAttendanceDto(
    DateTime EnterDateTime,
    DateTime LeaveDateTime
);
