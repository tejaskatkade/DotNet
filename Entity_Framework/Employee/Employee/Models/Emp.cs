using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Employee.Models
{
    public class Emp
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
        public string Designation { get; set; } = "";
        [Required]
        public float Salary { get; set; }
        
    }
}
