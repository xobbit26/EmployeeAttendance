using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data.Repository.RepoConfig;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly DataContext _dataContext;

    public RepositoryBase(DataContext repositoryContext)
    {
        _dataContext = repositoryContext;
    }

    public IQueryable<T> FindAll()
    {
        return _dataContext.Set<T>()
            .AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _dataContext.Set<T>()
            .Where(expression)
            .AsNoTracking();
    }

    public void Create(T entity)
    {
        _dataContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _dataContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dataContext.Set<T>().Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}