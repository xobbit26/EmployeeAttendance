using AutoMapper;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.DTOs;
using EmployeeAttendance.Exceptions;

namespace EmployeeAttendance.Services.Impl;

public class EmployeeAttendanceService : IEmployeeAttendanceService
{
    private const string EMPLOYEE_NOT_FOUND_MSG = "Emplooyee has not been found";


    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeAttendanceService(IMapper mapper, 
        IRepositoryWrapper repositoryWrapper, 
        IEmployeeService employeeService)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
        _employeeService = employeeService;
    }


    public async Task<IEnumerable<EmployeeAttendanceDto>> FindAllByEmployeeIdAsync(long employeeId)
    {
        _ = await _employeeService.FindByIdAsync(employeeId);
        var employeeAttendances = await _repositoryWrapper.EmployeeAttendance.FindByEmployeeIdAsync(employeeId);

        return employeeAttendances.Select(ea => _mapper.Map<EmployeeAttendanceDto>(ea));
    }


    public async Task EnterAsync(long employeeId)
    {
        var employeeEntity = await _repositoryWrapper.Employee.FindByIdAsync(employeeId);
        if (employeeEntity == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        var newEnter = new Data.Entities.EmployeeAttendance()
        {
            EnterDateTime = DateTime.Now,
            Employee = employeeEntity
        };

        _repositoryWrapper.EmployeeAttendance.Create(newEnter);
        await _repositoryWrapper.SaveAsync();
    }

    private Task ValidateEmloyee(long employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task LeaveAsync(long employeeId)
    {
        var employeeEntity = await _repositoryWrapper.Employee.FindByIdAsync(employeeId);
        if (employeeEntity == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        var newLeave = new Data.Entities.EmployeeAttendance()
        {
            LeaveDateTime = DateTime.Now,
            Employee = employeeEntity
        };

        _repositoryWrapper.EmployeeAttendance.Create(newLeave);
        await _repositoryWrapper.SaveAsync();
    }
}

