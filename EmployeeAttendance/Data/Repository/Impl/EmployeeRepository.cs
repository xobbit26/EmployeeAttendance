using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository.RepoConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data.Repository.Impl;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DataContext repositoryContext) : base(repositoryContext)
    {
    }


    public async Task<IEnumerable<Employee>> FindAllAsync()
    {
        return await FindAll()
            .OrderBy(e => e.Surname + e.Name)
            .ToListAsync();
    }

    public async Task<Employee> FindByIdAsync(long id)
    {
        return await FindAll()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}