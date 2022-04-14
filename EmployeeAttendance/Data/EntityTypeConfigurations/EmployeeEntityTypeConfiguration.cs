using EmployeeAttendance.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAttendance.Data.EntityTypeConfigurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(nameof(Employee.Name))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(nameof(Employee.Surname))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(nameof(Employee.Birthday))
            .IsRequired();

        builder.Property(nameof(Employee.HiringDate))
            .IsRequired();

        builder.Property(nameof(Employee.Position))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(nameof(Employee.Department))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(nameof(Employee.IsActive))
            .HasDefaultValue(false);

        builder
            .HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));
    }
}