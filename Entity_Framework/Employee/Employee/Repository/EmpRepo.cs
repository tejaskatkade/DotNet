using Employee.Models;
using Employee.Services;
using EmployeeManagement.DTO;

namespace EmployeeManagement.Repository
{
    public class EmpRepo : IEmpRepo
    {
        private readonly ApplicationDbContext _context;
        public EmpRepo(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void AddEmp(EmpDto empDto)
        {
            Emp emp = new Emp()
            {
                Name = empDto.Name,
                Department = empDto.Department,
                Designation = empDto.Designation,
                Salary = empDto.Salary
            };
            _context.employees.Add(emp);
            _context.SaveChanges();
        }

        public void DeleteEmp(int id)
        {
            var emp = _context.employees.Find(id);
            if (emp != null)
            {
                _context.employees.Remove(emp);
                _context.SaveChanges();
            }
        }

        public Emp GetEmp(int id)
        {
            return _context.employees.Find(id);
        }

        public List<Emp> GetEmps()
        {
            return _context.employees.ToList();
        }

        public void Update(int id,EmpDto empDto)
        {
            var emp = _context.employees.Find(id);

            if (emp != null)
            {
                emp.Name = empDto.Name;
                emp.Department = empDto.Department;
                emp.Designation = empDto.Designation;
                emp.Salary = empDto.Salary;

                //_context.employees.Add(emp);
                _context.SaveChanges();
            }

        }
    }
}
