namespace EmployeeAttendance.Data.Repository.RepoConfig;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DataContext _dataContext;

    public RepositoryWrapper(DataContext dataContext,
        IEmployeeRepository employeeRepository)
    {
        _dataContext = dataContext;
        Employee = employeeRepository;
    }

    public IEmployeeRepository Employee { get; }


    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}