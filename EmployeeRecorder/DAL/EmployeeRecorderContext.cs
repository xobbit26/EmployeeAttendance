using EmployeeRecorder.entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecorder.DAL
{
    public class EmployeeRecorderContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public EmployeeRecorderContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=пароль_от_postgres");
        }
    }
}
