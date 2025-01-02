using EmployeeApplication.Model;
using EmployeeApplication.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApplication.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public List<Department> Get()
        {
            return departmentService.GetAll();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return departmentService.GetById(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public string Post([FromBody] Department department)
        {
            return departmentService.AddDepartment(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public string Put([FromBody] Department department)
        {
            return departmentService.UpdateDepartment(department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return departmentService.DeleteDepartment(id);
        }
    }
}
