using AutoMapper;
using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.DTOs;

namespace EmployeeAttendance.Services.Impl;

public class EmployeeAttendanceService : IEmployeeAttendanceService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;
    private readonly IEmployeeService _employeeService;

    public EmployeeAttendanceService(IMapper mapper,
        IEmployeeAttendanceRepository employeeAttendanceRepository,
        IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeAttendanceRepository = employeeAttendanceRepository;
        _employeeService = employeeService;
    }


    public async Task<IEnumerable<EmployeeAttendanceDto>> FindAllByEmployeeIdAsync(long employeeId)
    {
        _ = await _employeeService.FindByIdAsync(employeeId);
        var employeeAttendances = await _employeeAttendanceRepository.FindByEmployeeIdAsync(employeeId);

        return _mapper.Map<List<EmployeeAttendanceDto>>(employeeAttendances);
    }


    public async Task EnterAsync(long employeeId)
    {
        var employee = await _employeeService.FindEntityByIdAsync(employeeId);

        var newEnter = new Data.Entities.EmployeeAttendance()
        {
            EnterDateTime = DateTime.Now,
            Employee = employee
        };

        _employeeAttendanceRepository.Create(newEnter);
        await _employeeAttendanceRepository.SaveAsync();
    }


    public async Task LeaveAsync(long employeeId)
    {
        var employee = await _employeeService.FindEntityByIdAsync(employeeId);

        var newLeave = new Data.Entities.EmployeeAttendance()
        {
            LeaveDateTime = DateTime.Now,
            Employee = employee
        };

        _employeeAttendanceRepository.Create(newLeave);
        await _employeeAttendanceRepository.SaveAsync();
    }
}

