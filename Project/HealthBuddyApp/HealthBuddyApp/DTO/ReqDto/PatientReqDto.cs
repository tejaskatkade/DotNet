using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.DTO.ReqDto
{
    public class PatientReqDto
    {
        [Required]
        public String FirstName { get; set; } = string.Empty;

        [Required]
        public String LastName { get; set; } = String.Empty;
        [Required]
        [EmailAddress]
        public String Email { get; set; } = string.Empty;

        [Required]
       // [RegularExpression(@"^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[#@$*]).{5,20}$",
       //  ErrorMessage = "Password must be 5-20 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one special character (#@$*).")]
        public String Password { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Age { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        public String? Symptoms { get; set; }
        public String? Address { get; set; }
    }
}
