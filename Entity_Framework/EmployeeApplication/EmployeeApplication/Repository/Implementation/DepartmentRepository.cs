using EmployeeApplication.Context;
using EmployeeApplication.Model;

namespace EmployeeApplication.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext empContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
                   this.empContext = employeeDbContext;
        }

        public int AddDepartment(Department department)
        {
            empContext.departments.Add(department);
            return empContext.SaveChanges();
        }

        public int DeleteDepartment(int departmentId)
        {
            Department department = GetById(departmentId);
            if (department != null)
            {

            empContext.departments.Remove(department);
            return empContext.SaveChanges();
            }
            return 0;
        }

        public List<Department> GetAll()
        {
            return empContext.departments.ToList();
        }

        public Department GetById(int id)
        {
            return empContext.departments.FirstOrDefault(d => d.Id == id);
        }

        public int UpdateDepartment(Department newDepartment)
        {
            Department department = empContext.departments.FirstOrDefault(d => d.Id == newDepartment.Id);

            if (department != null)
            {
                department.Name = newDepartment.Name;
                department.UpdatedDate = DateTime.Now;
                department.City = newDepartment.City;
                return empContext.SaveChanges();
            }
            return 0;
        }
    }
}
