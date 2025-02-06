
using HealthBuddyApp.Repository;
using HealthBuddyApp.Util;

namespace HealthBuddyApp.Service.Implementation
{
    public class TimeSlotServiceImpl : ITimeSlotService
    {
        private IAppointmentRepository appointmentRepository;
        public TimeSlotServiceImpl(IAppointmentRepository appointmentRepository) 
        {
            this.appointmentRepository = appointmentRepository;
        }
        public List<TimeSpan> getAvailableTimeSlotsForDay(long doctorId, string date, TimeSpan startTime, TimeSpan endTime)
        {
            List<TimeSpan> allTimeSlots =  TimeSlotUtil.GenerateTimeSlots(startTime, endTime);

            var bookedTimeSlots = appointmentRepository
           .findBookedTimeSlotsByDoctorAndDate(doctorId, DateTime.Parse(date))
           .Select(appointment => appointment.TimeSlot.StartTime)
           .ToList();

            // Step 2: Filter out booked slots from all time slots
            Console.WriteLine(string.Join(", ", allTimeSlots));
            return allTimeSlots
                .Where(slot => !bookedTimeSlots.Contains(slot))
                .ToList();

        }
    }
}
