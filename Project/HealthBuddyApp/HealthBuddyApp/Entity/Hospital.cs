namespace HealthBuddyApp.Entity
{
    public class Hospital : BaseEntity
    {

        public string Name {  get; set; }
        public String Location { get; set; }
        public String Contact { get; set; }
        public Boolean IsActive { get; set; } = true;

        public List<Doctor> Doctors { get; set; } = [];
    }
}
