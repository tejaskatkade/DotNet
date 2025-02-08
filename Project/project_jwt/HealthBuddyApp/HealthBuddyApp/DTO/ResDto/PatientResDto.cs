using System.Text.Json.Serialization;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.DTO.ResDto
{
    public class PatientResDto
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        public String Symptoms { get; set; }
    }
}
