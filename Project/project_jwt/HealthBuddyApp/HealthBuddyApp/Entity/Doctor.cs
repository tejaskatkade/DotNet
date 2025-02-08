using System.Xml;
using System;

namespace HealthBuddyApp.Entity
{
    public class Doctor : BaseEntity
    {
       

        public String Name {  get; set; }
        public String Specialization {  get; set; }
        public int Experience { get; set; }
        //@Column(unique = true, nullable = false)
        public String Email { get; set; }
        public String Contact {  get; set; }

        public List<Hospital> Hospitals { get; set; } = [];

        public List<Appointment> Appointments { get; set; } = [];
        public User User { get; set; }
    }

}