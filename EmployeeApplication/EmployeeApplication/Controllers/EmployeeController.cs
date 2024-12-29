using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            this.employeeService = employeeService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = employeeService.GetAll();
           // this.ViewBag.Employees = employees;
            return View(employees);
        }

        // GET: BookEmployee/GetEmployee/5
        public ActionResult GetEmployee(int id)
        {
            Employee employee = employeeService.GetEmployee(id);
            this.ViewBag.Employee = employee;
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            
            employeeService.AddEmployee(employee); 
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Employee/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
             employeeService.UpdateEmployee(employee);
             return RedirectToAction(nameof(Index));
            
        }

       

        // POST: BookController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));     
        }
    }
}
