using System.Text.Json.Serialization;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.DTO.ResDto
{
    public class AppointmentResDto
    {
        public long Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentStatus Status { get; set; }
        public String DoctorName { get; set; }
        public String HospitalName { get; set; }
        public string StartTime {  get; set; }
        public String PatientName {  get; set; }
    }
}
