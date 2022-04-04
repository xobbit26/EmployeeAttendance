using EmployeeAttendance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Entities.EmployeeAttendance> EmployeeAttendance { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));
    }
}
