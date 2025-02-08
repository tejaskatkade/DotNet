using System.ComponentModel.DataAnnotations;

namespace HealthBuddyApp.Entity
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
