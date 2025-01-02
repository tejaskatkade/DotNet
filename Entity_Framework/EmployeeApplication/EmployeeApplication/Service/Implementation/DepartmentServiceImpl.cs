using EmployeeApplication.Model;
using EmployeeApplication.Repository;

namespace EmployeeApplication.Service.Implementation
{
    public class DepartmentServiceImpl : IDepartmentService

    {
        private readonly IDepartmentRepository repository;
        public DepartmentServiceImpl(IDepartmentRepository repository) 
        {
            this.repository = repository;
        }

        public string AddDepartment(Department department)
        {
            if(repository.AddDepartment(department) > 0)
            {
                return "Department Added";
            }
            return "Department Not Added";
        }

        public string DeleteDepartment(int departmentId)
        {
            if (repository.DeleteDepartment(departmentId) > 0)
            {
                return "Department Deleted";
            }
            return "Department Not Deleted";
        }

        public List<Department> GetAll()
        {
            return repository.GetAll();
        }

        public Department GetById(int id)
        {
            return repository.GetById(id);
        }

        public string UpdateDepartment(Department department)
        {
            if (repository.UpdateDepartment(department) > 0)
            {
                return "Department Added";
            }
            return "Department Not Added";
        }
    }
}
