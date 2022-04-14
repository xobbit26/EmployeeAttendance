namespace EmployeeAttendance.Data.Repository.RepoConfig;

public interface IRepositoryWrapper
{
    IEmployeeRepository Employee { get; }
    Task SaveAsync();
}