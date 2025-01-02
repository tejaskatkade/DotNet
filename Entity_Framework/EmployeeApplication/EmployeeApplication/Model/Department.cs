namespace EmployeeApplication.Model
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }

        public List<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
