using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IEmpolyeeRepository
    {
        Employee GetPerson(int id);
        List<Employee> GetPersons();
        bool AddPerson(Employee employee);
        bool DeletePerson(int id);
        bool UpdatePerson(Employee employee);
    }
}
