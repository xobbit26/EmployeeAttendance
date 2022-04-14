namespace EmployeeAttendance.Data.Repository.RepoConfig;

public interface IRepositoryWrapper
{
    IEmployeeRepository Employee { get; }

    IEmployeeAttendanceRepository EmployeeAttendance { get; }

    Task SaveAsync();
}