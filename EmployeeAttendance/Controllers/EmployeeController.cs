using EmployeeAttendance.dto;
using EmployeeAttendance.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers
{
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
        public IEnumerable<EmployeeDto> GetAllEmployees() => 
            _employeeService.GetAllEmployees();


        [HttpPost]
        public void Create(EmployeeDto employee) => 
            _employeeService.Create(employee);
    }

}
