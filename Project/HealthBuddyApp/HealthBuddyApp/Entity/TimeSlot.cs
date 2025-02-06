namespace HealthBuddyApp.Entity
{
    public class TimeSlot : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}