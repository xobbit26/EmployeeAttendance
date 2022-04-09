using EmployeeAttendance.Dto;

namespace EmployeeAttendance.Service.Impl;

public class EmployeeService : IEmployeeService
{
    private List<EmployeeDto> _employees = new List<EmployeeDto>();



    async Task<IEnumerable<EmployeeDto>> IEmployeeService.GetAllEmployeesAsync() 
    {
        return await Task.FromResult(_employees);
    }


    async Task IEmployeeService.CreateAsync(EmployeeDto employee)
    {
        if (employee != null)
        {
            if (employee.Name != null)
            {
                _employees.Add(employee);
            }
        }
    }
}
