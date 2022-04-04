using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRecorder.entity;

[Table("employee")]
public class Employee
{
    //[Key]
    //[Column("id")]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [MaxLength(50)]
    public string Surname { get; set; } = null!;

    public int Age { get; set; }

    public DateTime HiringDate { get; set; }

    [MaxLength(100)]
    public string Position { get; set; } = null!;

    public bool IsActive { get; set; }

    //public string Country { get; set; } = null!;
}
