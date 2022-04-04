using EmployeeAttendance.Dto;

namespace EmployeeAttendance.Service;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployees();

    void Create(EmployeeDto employee);
}
