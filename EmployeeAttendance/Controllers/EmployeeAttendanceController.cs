using EmployeeAttendance.DTOs;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeAttendanceController : ControllerBase
{
    private readonly IEmployeeAttendanceService _employeeAttendanceService;

    public EmployeeAttendanceController(IEmployeeAttendanceService employeeAttendanceService)
    {
        _employeeAttendanceService = employeeAttendanceService;
    }



    [HttpGet("{employeeId}")]
    public async Task<IEnumerable<EmployeeAttendanceDto>> GetByEmployeeId(long employeeId)
        => await _employeeAttendanceService.FindAllByEmployeeIdAsync(employeeId);


    [HttpPost("enter/{emloyeeId}")]
    public async void Enter(long emloyeeId) => await _employeeAttendanceService.EnterAsync(emloyeeId);


    [HttpPost("leave/{emloyeeId}")]
    public async void Leave(long emloyeeId) => await _employeeAttendanceService.LeaveAsync(emloyeeId);
}

