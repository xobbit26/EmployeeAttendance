using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Entities.EmployeeAttendance> EmployeeAttendance { get; set; } = null!;


    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeeEntityTypeConfiguration()
            .Configure(modelBuilder.Entity<Employee>());
    }
}
