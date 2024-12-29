using Model;
using Repository;

namespace Service
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private IEmpolyeeRepository empolyeeRepository;
        public EmployeeServiceImpl(IEmpolyeeRepository empolyeeRepository) {
            this.empolyeeRepository = empolyeeRepository;
        }
        public string AddEmployee(Employee employee)
        {
            string res = "Employee Not Added";
            if (empolyeeRepository.AddPerson(employee))
            {
                res = "Employee Added";
            }
            return res;
        }

        public string DeleteEmployee(int id)
        {
            string res = "Employee Not Deleted";
            if (empolyeeRepository.DeletePerson(id))
            {
                res = "Employee Deleted";
            }
            return res;

        }

        public List<Employee> GetAll()
        {
            return empolyeeRepository.GetPersons();
        }

        public Employee GetEmployee(int id)
        {
            return empolyeeRepository.GetPerson(id);
        }

        public string UpdateEmployee(Employee employee)
        {
            string res = "Employee Not Updated";
            if (empolyeeRepository.UpdatePerson(employee))
            {
                res = "Employee Updated";
            }
            return res;
        }
    }
}
