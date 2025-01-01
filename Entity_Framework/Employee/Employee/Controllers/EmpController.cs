using Employee.Models;
using EmployeeManagement.DTO;
using EmployeeManagement.Repository;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpRepo _empRepo;
        public EmpController(IEmpRepo empRepo) {
            _empRepo = empRepo;
        }
        public ActionResult Index()
        {
            return View(_empRepo.GetEmps());
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            return View(_empRepo.GetEmp(id));
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpDto empDto)
        {
            try
            {
                _empRepo.AddEmp(empDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            Emp emp = _empRepo.GetEmp(id);
            return View(emp);
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpDto empDto)
        {
            try
            {
                _empRepo.Update(id, empDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Delete/5
        /*public ActionResult Delete(int id)
        {

            return View();
        }*/

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _empRepo.DeleteEmp(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
