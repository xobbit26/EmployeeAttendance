using EmployeeAttendance.Data.Repository.RepoConfig;

namespace EmployeeAttendance.Data.Repository;


public interface IEmployeeAttendanceRepository : IRepositoryBase<Entities.EmployeeAttendance>
{
    Task<IEnumerable<Entities.EmployeeAttendance>> FindByEmployeeIdAsync(long employeeId);
}
