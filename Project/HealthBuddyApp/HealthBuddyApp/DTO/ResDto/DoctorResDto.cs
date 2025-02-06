using System.ComponentModel.DataAnnotations;

namespace HealthBuddyApp.DTO.ResDto
{
    public class DoctorResDto
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public String Specialization { get; set; }
        public int Experience   { get; set; }
        public String Email {  get; set; }
        public String Contact { get; set; }
    }
}
