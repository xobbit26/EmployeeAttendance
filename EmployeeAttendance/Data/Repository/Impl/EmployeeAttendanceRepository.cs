using EmployeeAttendance.Data.Repository.RepoConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data.Repository.Impl;

public class EmployeeAttendanceRepository : RepositoryBase<Entities.EmployeeAttendance>, IEmployeeAttendanceRepository
{
    public EmployeeAttendanceRepository(DataContext repositoryContext) : base(repositoryContext) { }


    public async Task<IEnumerable<Entities.EmployeeAttendance>> FindByEmployeeIdAsync(long employeeId)
        => await FindByCondition(e => e.Employee.Id == employeeId).ToListAsync();
}
