using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        List<Employee> GetAll();
        string AddEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);

    }
}
