using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.Service;
using HealthBuddyApp.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private IEmailService emailService;
        public EmailController(IEmailService emailServiceImpl)
        {
            emailService = emailServiceImpl;
        }



        // POST api/<EmailController>
        [HttpPost("SendEmail")]
        public void sendEmail([FromBody] EmailVerificationReqDto dto)
        {
            int otp = emailService.generateOtp();
            emailService.setOtp(otp);
            emailService.sendEmail( dto.Email,"Verification Mail" ,"OTP : "+otp);
        }

        [HttpPost("VerifyEmail")]
        public bool verifyEmail([FromBody] EmailVerificationReqDto dto)
        {
            return emailService.verifyOtp(dto.otp);
        }

        
    }
}
