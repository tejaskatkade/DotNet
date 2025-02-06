namespace HealthBuddyApp.DTO.ReqDto
{
    public class AppointmentReqDto
    {
        public String AppointmentDate { get; set; }
        //private AppointmentStatus status;
        public long DoctorId { get; set; }
        public long HospitalId { get; set; }
        public String TimeSlot { get; set; } = string.Empty;
        public long PatientId { get; set; }
    }
}
