using Employee.Models;
using EmployeeManagement.DTO;

namespace EmployeeManagement.Repository
{
    public interface IEmpRepo
    {
        void AddEmp(EmpDto empDto);
        Emp GetEmp(int id);
        List<Emp> GetEmps();
        void Update(int id,EmpDto empDto);  
        void DeleteEmp(int id);
    }
}
