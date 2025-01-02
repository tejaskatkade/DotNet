using EmployeeApplication.Context;
using EmployeeApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext context;
        public EmployeeRepository(EmployeeDbContext context) {
            this.context = context;
        } 
        public string AddEmployee(Employee employee)
        { 
            Department department = context.departments.Find(employee.DepartmentId);
            if (department != null)
            {
                department.Employees.Add(employee);
                employee.Department = department;
                context.employees.Add(employee);
                context.SaveChanges();
                return "Employee Added";

            }
            return "Department Not Found";
        }

        public string DeleteEmployee(int id)
        {
            Employee employee = context.employees.FirstOrDefault(e => e.Id == id);
            if (employee != null) { 
                context.employees.Remove(employee);
                context.departments.Find(employee.DepartmentId).Employees.Remove(employee);
                context.SaveChanges();
                return "Employee Deleted";
            }
             return "Employee Not Deleted";
        }


        public List<Employee> GetAllEmployees()
        {
            return context.employees.Include(dept => dept.Department).ToList();
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = context.employees.Include(dept => dept.Department).FirstOrDefault(e => e.Id == id);
            
                return employee;
        }

        public string UpdateEmployee(Employee newEmployee)
        {
            Employee employee = context.employees.Include(dept => dept.Department).FirstOrDefault(e => e.Id == newEmployee.Id);
            if (employee != null)
            {
                employee.Id = newEmployee.Id;
                employee.Name = newEmployee.Name;
                employee.Role = newEmployee.Role;
                employee.UpdatedDate = DateTime.Now;
                employee.Department = context.departments.Find(newEmployee.DepartmentId);
                
                context.SaveChanges();

                return "Employee Updated";
            }
            return "Employee Not Update";
        }
    }
}
