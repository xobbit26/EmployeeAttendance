using EmployeeRecorder.dto;

namespace EmployeeRecorder.service.impl
{
    public class EmployeeService : IEmployeeService
    {
        private List<EmployeeDto> _employees = new List<EmployeeDto>();

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _employees;
        }

        public void Create(EmployeeDto employee)
        {
            _employees.Add(employee);
        }
    }
}
