using EmployeeApplication.Context;
using EmployeeApplication.Model;

namespace EmployeeApplication.Repository
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        List<Department> GetAll();
        int AddDepartment(Department department);
        int UpdateDepartment(Department department);

        int DeleteDepartment(int departmentId);
        
    }
}
