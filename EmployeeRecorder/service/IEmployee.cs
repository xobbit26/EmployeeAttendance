using EmployeeRecorder.dto;

namespace EmployeeRecorder.service
{
    public interface IEmployee
    {
        IEnumerable<EmployeeDto> GetEmployees();
    }
}
