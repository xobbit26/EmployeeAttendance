using EmployeeAttendance.DTOs;

namespace EmployeeAttendance.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> FindAllAsync();

    Task<EmployeeDto> FindByIdAsync(long id);

    Task CreateAsync(EmployeeDto employee);

    Task UpdateAsync(EmployeeDto employee);

    Task DeleteAsync(long id);
}