using System.Text.Json.Serialization;

namespace HariomToppersAcademy.Entity
{
    public class CourseName : BaseEntity
    {
        public string Name { get; set; }
        public double Fees { get; set; }
        [JsonIgnore]
        public List<Student> Students { get; set; } = [];
    }
}