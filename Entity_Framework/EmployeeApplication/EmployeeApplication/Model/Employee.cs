using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeApplication.Model
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department Department { get; set; } = null!;
        public string Role { get; set; }
    }
}
