using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data.Repository.Impl;


public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DataContext repositoryContext) : base(repositoryContext) { }


    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await FindAll()
            .OrderBy(e => e.Name)
            .ToListAsync();
    }
}
