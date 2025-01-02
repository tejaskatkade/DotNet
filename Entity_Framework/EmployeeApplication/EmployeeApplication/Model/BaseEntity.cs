using System.ComponentModel.DataAnnotations;

namespace EmployeeApplication.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
