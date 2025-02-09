using System.Net.Mail;
using System.Reflection;
using Org.BouncyCastle.Utilities;

namespace HealthBuddyApp.Service.Implementation
{
    public class EmailServiceImpl : IEmailService
    {
        private IConfiguration _configuration;

        private int otpValue = 000000;
        public EmailServiceImpl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void setOtp(int otp)
        {
            this.otpValue = otp;
        }

        public void sendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new System.Net.NetworkCredential(
                    _configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true

            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:From"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,

            };

            mailMessage.To.Add(to);
            smtpClient.Send(mailMessage);

        }

        public int generateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999); // Generates a number between 100000 and 999999
        }

        public Boolean verifyOtp(int otp)
        {
            if(otp == otpValue)
            {
                return true;
            }
            return false;
        }


    }
}
