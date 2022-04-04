using EmployeeAttendance.dto;

namespace EmployeeAttendance.service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();

        void Create(EmployeeDto employee);
    }
}
