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
        //Employee Settings
        modelBuilder.Entity<Employee>()
            .HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));

        modelBuilder.Entity<Employee>().Property(nameof(Employee.Name)).HasMaxLength(50);
        modelBuilder.Entity<Employee>().Property(nameof(Employee.Surname)).HasMaxLength(50);
        modelBuilder.Entity<Employee>().Property(nameof(Employee.Position)).HasMaxLength(100);
    }
}
