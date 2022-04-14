using AutoMapper;
using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.DTOs;
using EmployeeAttendance.Exceptions;

namespace EmployeeAttendance.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private const string EMPLOYEE_NOT_FOUND_MSG = "Emplooyee has not been found";

    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EmployeeService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<IEnumerable<EmployeeDto>> FindAllAsync()
    {
        var employees = await _repositoryWrapper.Employee.FindAllAsync();
        return employees.Select(e => _mapper.Map<EmployeeDto>(e));
    }


    public async Task<EmployeeDto> FindByIdAsync(long id)
    {
        var employee = await _repositoryWrapper.Employee.FindByIdAsync(id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        return _mapper.Map<EmployeeDto>(employee);
    }


    public async Task CreateAsync(EmployeeDto employee)
    {
        var employeeEntity = _mapper.Map<Employee>(employee);
        _repositoryWrapper.Employee.Create(employeeEntity);

        await _repositoryWrapper.SaveAsync();
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = await _repositoryWrapper.Employee.FindByIdAsync(employeeDto.Id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        _mapper.Map(employeeDto, employee);

        _repositoryWrapper.Employee.Update(employee);
        await _repositoryWrapper.SaveAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var employee = await _repositoryWrapper.Employee.FindByIdAsync(id);
        if (employee == null)
            throw new EmployeeNotFoundException(EMPLOYEE_NOT_FOUND_MSG);

        _repositoryWrapper.Employee.Delete(employee);
        await _repositoryWrapper.SaveAsync();
    }
}