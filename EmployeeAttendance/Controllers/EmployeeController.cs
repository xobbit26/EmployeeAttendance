using EmployeeAttendance.DTO;
using EmployeeAttendance.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpGet("all-employees")]
    public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        => await _employeeService.GetAllEmployeesAsync();


    [HttpPost]
    public async Task Create(EmployeeDto employee)
        => await _employeeService.Create(employee);

}
