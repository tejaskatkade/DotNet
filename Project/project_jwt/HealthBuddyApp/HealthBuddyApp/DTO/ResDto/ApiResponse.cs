namespace HealthBuddyApp.DTO.ResDto
{
    public class ApiResponse
    {
        private ApiResponse apiResponse;

        public DateTime TimeStamp { get; set; }
        public String Message { get; set; }
        public ApiResponse(String Message)
        {
            this.Message = Message;
            this.TimeStamp = DateTime.Now;
        }

        
    }
}
