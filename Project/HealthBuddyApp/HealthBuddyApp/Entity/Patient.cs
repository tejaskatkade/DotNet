using System.Reflection;
using System.Xml.Linq;
using System.Xml;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthBuddyApp.Entity
{
    public class Patient : BaseEntity 
    {
        public String FirstName {  get; set; }
        public String LastName { get; set; }

        private String Email {  get; set; }
        public String Address { get; set; }
        public int Age { get; set; }
        public Gender Gender    { get; set; }
        public String Symptoms { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long UserId { get; set; }
        public List<Appointment> Appointments { get; set; } = [];
    }
}