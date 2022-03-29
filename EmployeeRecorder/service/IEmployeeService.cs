using EmployeeRecorder.dto;

namespace EmployeeRecorder.service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();

        void Create(EmployeeDto employee);
    }
}
