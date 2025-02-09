namespace HealthBuddyApp.Service
{
    public interface IEmailService
    {
        public void sendEmail(string to, string subject, string body);
        public int generateOtp();
        public Boolean verifyOtp(int otp);
        public void setOtp(int otp);
    }
}
