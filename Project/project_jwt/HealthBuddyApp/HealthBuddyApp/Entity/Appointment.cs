using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthBuddyApp.Entity
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointementDate {  get; set; }
        public AppointmentStatus Status { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public long DoctorId { get; set; }

        [ForeignKey("HospitalId")]
        public Hospital Hospital { get; set; }
        public long HospitalId { get; set; }

        [ForeignKey("TimeSlotId")]
        public TimeSlot TimeSlot { get; set; }
        public long TimeSlotId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public long PatientId { get; set; }
    }

    public enum AppointmentStatus
    {
        PENDING,
        COMPLETED,
        CANCELLED
    }
}