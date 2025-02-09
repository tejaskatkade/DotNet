using System.ComponentModel.DataAnnotations;

namespace HealthBuddyApp.DTO.ReqDto
{
    public class EmailVerificationReqDto
    {
        [EmailAddress]
        public String Email { get; set; }

        public int otp { get; set; }
    }
}
