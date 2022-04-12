using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;

namespace EmployeeAttendance.Data.Repository;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
