using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HealthBuddyApp.DTO.ReqDto
{
    public class DoctorReqDto
    {
        [Required]
        public String Name { get; set; } = string.Empty;
        public String Specialization {  get; set; } = string.Empty;
        public int Experience { get; set; }

        [EmailAddress]
        public String Email {  get; set; }

        [Required]
       // [RegularExpression(@"^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[#@$*]).{5,20}$",
        // ErrorMessage = "Password must be 5-20 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one special character (#@$*).")]
        public String Password { get; set; }


       // [RegularExpression(@"^(\\+91[\\-\\s]?)?[0]?(91)?[789]\\d{9}")]
        public String Contact { get; set; }
    }
}
