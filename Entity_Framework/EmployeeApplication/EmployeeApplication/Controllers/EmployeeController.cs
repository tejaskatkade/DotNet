using EmployeeApplication.Model;
using EmployeeApplication.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApplication.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            this.employeeService = employeeService;
        }

        // GET: /<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return employeeService.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeService.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee employee)
        {
            return employeeService.AddEmployee(employee);
        }

        // PUT /<EmployeeController>/5
        [HttpPut]
        public string Put([FromBody] Employee employee)
        {
            return employeeService.UpdateEmployee(employee);
        }

        // DELETE /<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return employeeService.DeleteEmployee(id);
        }
    }
}
