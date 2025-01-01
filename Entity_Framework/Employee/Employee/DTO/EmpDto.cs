using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTO
{
    public class EmpDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Department { get; set; } = "";
        [Required, MaxLength(100)]
        public string Designation { get; set; } = "";
        [Required]
        public float Salary { get; set; }
    }
}
