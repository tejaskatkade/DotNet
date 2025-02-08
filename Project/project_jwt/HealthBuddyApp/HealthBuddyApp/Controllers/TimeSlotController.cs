using HealthBuddyApp.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private ITimeSlotService timeSlotService;
        public TimeSlotController(ITimeSlotService timeSlotService) 
        {
           this.timeSlotService = timeSlotService;
        }
        
        [HttpGet("available/doctor/{doctorId}/date/{date}")]
        public List<TimeSpan> Get(long doctorId, String date)
        {
            TimeSpan start = TimeSpan.Parse("10:00:00");
            TimeSpan end = TimeSpan.Parse("16:00:00");
            return timeSlotService.getAvailableTimeSlotsForDay(doctorId, date, start, end);    
        }
    }
}
