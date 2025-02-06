namespace HealthBuddyApp.Service
{
    public interface ITimeSlotService
    {

        public List<TimeSpan> getAvailableTimeSlotsForDay(long doctorId, String date, TimeSpan startTime, TimeSpan endTime);
    }
}
