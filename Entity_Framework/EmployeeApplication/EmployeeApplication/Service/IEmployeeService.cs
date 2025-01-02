using EmployeeApplication.Model;
using EmployeeApplication.Repository;

namespace EmployeeApplication.Service
{
    public interface IEmployeeService
    {
        public string AddEmployee(Employee employee);
        public Employee GetById(int id);
        public List<Employee> GetAll();
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(int id);


    }
}
