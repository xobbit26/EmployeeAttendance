using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.Dto;

namespace EmployeeAttendance.Service.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EmployeeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await _repositoryWrapper.Employee.GetAllEmployeesAsync();
        return employees.Select(MapEmployeeToDto);

        static EmployeeDto MapEmployeeToDto(Employee employee) => new()
        {
            Id = employee.Id,
            Name = employee.Name,
            Surname = employee.Surname,
            Birthday = employee.Birthday.ToString(),
            HiringDate = employee.HiringDate.ToString(),
            Position = employee.Position,
            Department = employee.Department,
            IsActive = employee.IsActive
        };
    }


    public async Task Create(EmployeeDto employee)
    {
        var employeeEntity = new Employee()
        {
            Id = employee.Id,
            Name = employee.Name,
            Surname = employee.Surname,
            Birthday = DateOnly.ParseExact(employee.Birthday, "dd.MM.yyyy"),
            HiringDate = DateOnly.ParseExact(employee.HiringDate, "dd.MM.yyyy"),
            Position = employee.Position,
            Department = employee.Department,
            IsActive = employee.IsActive
        };
        _repositoryWrapper.Employee.Create(employeeEntity);

        await _repositoryWrapper.SaveAsync();
    }
}
