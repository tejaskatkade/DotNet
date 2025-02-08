using System;
using System.Collections.Generic;
namespace HealthBuddyApp.Util
{

    public class TimeSlotUtil
    {
  
        public static List<TimeSpan> GenerateTimeSlots(TimeSpan startTime, TimeSpan endTime, int durationMinutes = 30)
        {
            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be earlier than end time.");
            }

            List<TimeSpan> timeSlots = new List<TimeSpan>();
            TimeSpan slot = startTime;

            while (slot < endTime)
            {
                timeSlots.Add(slot);
                slot = slot.Add(TimeSpan.FromMinutes(durationMinutes));
            }

            return timeSlots;
        }
    }

}
