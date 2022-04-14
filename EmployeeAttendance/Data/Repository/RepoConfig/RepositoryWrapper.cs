namespace EmployeeAttendance.Data.Repository.RepoConfig;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DataContext _dataContext;

    //todo: find out how many repositories will be injected when we inject RepositoryWrapper
    public RepositoryWrapper(DataContext dataContext,
        IEmployeeRepository employeeRepository,
        IEmployeeAttendanceRepository employeeAttendance)
    {
        _dataContext = dataContext;
        Employee = employeeRepository;
        EmployeeAttendance = employeeAttendance;
    }

    public IEmployeeRepository Employee { get; }

    public IEmployeeAttendanceRepository EmployeeAttendance { get; }


    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}