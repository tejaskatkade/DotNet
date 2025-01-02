using EmployeeApplication.Model;
using EmployeeApplication.Repository;

namespace EmployeeApplication.Service.Implementation
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeServiceImpl(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public string AddEmployee(Employee employee)
        {
            return employeeRepository.AddEmployee(employee);
        }

        public string DeleteEmployee(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAllEmployees();
        }

        public Employee GetById(int id)
        {
            return employeeRepository.GetEmployee(id);
        }

        public string UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee); 
        }
    }
}
