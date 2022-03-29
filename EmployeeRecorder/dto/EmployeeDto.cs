namespace EmployeeRecorder.dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HiringDate { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
    }
}
