namespace EmployeeAttendance.Repository.RepoConfig;


public interface IRepositoryWrapper
{
    IEmployeeRepository Employee { get; }
    Task SaveAsync();
}
