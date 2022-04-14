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


    [HttpGet]
    public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        => await _employeeService.FindAllAsync();


    [HttpGet("{id}")]
    public async Task<EmployeeDto> GetById(long id)
        => await _employeeService.FindByIdAsync(id);


    [HttpPost]
    public async Task Create(EmployeeDto employee)
        => await _employeeService.CreateAsync(employee);


    [HttpPut]
    public async Task Update(EmployeeDto employee)
        => await _employeeService.UpdateAsync(employee);


    [HttpDelete("{id}")]
    public async Task Delete(long id)
        => await _employeeService.DeleteAsync(id);

}
