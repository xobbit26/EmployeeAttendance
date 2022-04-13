using AutoMapper;
using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.Dto;

namespace EmployeeAttendance.Service.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EmployeeService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await _repositoryWrapper.Employee.GetAllEmployeesAsync();
        return employees.Select(e => _mapper.Map<EmployeeDto>(e));
    }


    public async Task Create(EmployeeDto employee)
    {
        var employeeEntity = _mapper.Map<Employee>(employee);
        _repositoryWrapper.Employee.Create(employeeEntity);
        
        await _repositoryWrapper.SaveAsync();
    }
}