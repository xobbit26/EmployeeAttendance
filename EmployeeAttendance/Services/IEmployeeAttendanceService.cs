using EmployeeAttendance.DTOs;

namespace EmployeeAttendance.Services;


public interface IEmployeeAttendanceService
{
    Task<IEnumerable<EmployeeAttendanceDto>> FindAllByEmployeeIdAsync(long employeeId);
    Task EnterAsync(long employeeId);
    Task LeaveAsync(long employeeId);
}
