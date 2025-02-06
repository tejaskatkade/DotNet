using Microsoft.AspNetCore.Identity;

namespace HealthBuddyApp.Entity
{
    public class User : BaseEntity
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public UserRole Role {  get; set; }
        public bool IsActive { get; set; }
    }
}