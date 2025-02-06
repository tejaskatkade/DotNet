using System.ComponentModel.DataAnnotations;

namespace HealthBuddyApp.DTO.ReqDto
{
    public class HospitalReqDto
    {
        [Required]
        public String Name { get; set; }  = String.Empty;
        [Required]
        public String Location { get; set; } = String.Empty;
        [EmailAddress]
        public String Contact { get; set; } = string.Empty;
    }
}
