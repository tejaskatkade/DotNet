using System.Text.Json.Serialization;

namespace HariomToppersAcademy.Entity
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //[JsonIgnore]
        public List<CourseName> courseNames { get; set; } = [];
    }
}
