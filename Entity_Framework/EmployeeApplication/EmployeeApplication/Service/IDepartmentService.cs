using EmployeeApplication.Model;

namespace EmployeeApplication.Service
{
    public interface IDepartmentService
    {
        Department GetById(int id);
        List<Department> GetAll();
        string AddDepartment(Department department);
        string UpdateDepartment(Department department);

        string DeleteDepartment(int departmentId);
    }
}
