using EmployeeAttendance.DTO;

namespace EmployeeAttendance.Service;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

    Task Create(EmployeeDto employee);
}
