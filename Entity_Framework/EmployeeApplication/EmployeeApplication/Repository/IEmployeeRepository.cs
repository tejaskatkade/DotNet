using EmployeeApplication.Model;

namespace EmployeeApplication.Repository
{
    public interface IEmployeeRepository
    {
        string AddEmployee(Employee employee);
        string DeleteEmployee(int id);

        Employee GetEmployee(int id);

        List<Employee> GetAllEmployees();

        string UpdateEmployee(Employee employee);
    }
}
