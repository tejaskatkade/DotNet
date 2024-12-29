using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Model
{
    public class Person
    {
        public Person() { }
        public Person(int ID,string Name,int Age) {
            this.Id = ID;
            this.Name = Name;
            this.Age = Age;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
