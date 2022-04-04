using EmployeeAttendance.Dto;

namespace EmployeeAttendance.Service.Impl;

public class EmployeeService : IEmployeeService
{
    private List<EmployeeDto> _employees = new List<EmployeeDto>();


    public IEnumerable<EmployeeDto> GetAllEmployees() => _employees;
    public void Create(EmployeeDto employee) => _employees.Add(employee);
}
