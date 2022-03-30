using EmployeeRecorder.entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecorder.DAL
{
    public class EmployeeRecorderDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public EmployeeRecorderDbContext(DbContextOptions<EmployeeRecorderDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Age)
            //    .HasDefaultValue(18);

            modelBuilder.Entity<Employee>()
                .HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));
            //.HasData(new Employee { Id = 1, Name = "Tom", Age = 23 });
        }

        //public EmployeeRecorderDbContext(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Database.EnsureDeleted();
        //    Database.EnsureCreated();

        //    bool isConnected = Database.CanConnect();
        //    Console.WriteLine($"is connected to db: {isConnected}");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=employee_recorder_db;Username=root;Password=root");
        //    optionsBuilder.LogTo(Console.WriteLine);
        //}
    }
}
