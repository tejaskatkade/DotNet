using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee : Person
    {
        public Employee() { }      
        public Employee(int Id, string Name, int Age, string Department, string Designation,float Salary):base(Id,Name,Age) 
        {
            this.Designation = Designation;
            this.Salary = Salary;
            this.Department = this.Department;
        
        }      
        public string Department {  get; set; }
        public string Designation {  get; set; }
        public float Salary { get; set; }   

    }
}
