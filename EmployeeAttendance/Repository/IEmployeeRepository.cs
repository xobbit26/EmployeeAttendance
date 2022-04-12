using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Repository.RepoConfig;

namespace EmployeeAttendance.Repository;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
