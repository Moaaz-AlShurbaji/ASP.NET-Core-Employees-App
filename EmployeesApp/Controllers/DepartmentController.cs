using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Controllers
{
    public class DepartmentController : Controller
    {
        HRDatabaseContext db = new HRDatabaseContext();
        public IActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            TempData["message"] = "Department added successfuly";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var department = db.Departments.Where(dep => dep.DepartmentID == Id).First();
            db.Departments.Remove(department);
            db.SaveChanges();
            TempData["message"] = "Department Removed";
            return RedirectToAction("Index");
        }
    }
}