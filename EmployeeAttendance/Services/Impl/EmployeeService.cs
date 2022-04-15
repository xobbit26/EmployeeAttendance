using AutoMapper;
using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.DTOs;
using EmployeeAttendance.Exceptions;

namespace EmployeeAttendance.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private const string EMPLOYEE_NOT_FOUND_MSG = "Emplooyee has not been found";

    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IMapper mapper,
        IEmployeeRepository employeeRepository,
        ILogger<EmployeeService> logger)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
        _logger = logger;
    }


    public async Task<IEnumerable<EmployeeDto>> FindAllAsync()
    {
        _logger.LogInformation("*************FindAllAsync method (info)");
        _logger.LogWarning("*************FindAllAsync method (warning)");
        _logger.LogError("*************FindAllAsync method (error)");
        _logger.LogCritical("*************FindAllAsync method (critical)");
        _logger.LogTrace("*************FindAllAsync method (trace)");
        var employees = await _employeeRepository.FindAllAsync();
        return employees.Select(e => _mapper.Map<EmployeeDto>(e));
    }

    public async Task<EmployeeDto> FindByIdAsync(long id)
    {
        var employee = await _employeeRepository.FindByIdAsync(id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<Employee> FindEntityByIdAsync(long id)
    {
        var employee = await _employeeRepository.FindByIdAsync(id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        return employee;
    }

    public async Task CreateAsync(EmployeeDto employee)
    {
        var employeeEntity = _mapper.Map<Employee>(employee);
        _employeeRepository.Create(employeeEntity);

        await _employeeRepository.SaveAsync();
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.FindByIdAsync(employeeDto.Id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        _mapper.Map(employeeDto, employee);

        _employeeRepository.Update(employee);
        await _employeeRepository.SaveAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var employee = await _employeeRepository.FindByIdAsync(id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        _employeeRepository.Delete(employee);
        await _employeeRepository.SaveAsync();
    }
}