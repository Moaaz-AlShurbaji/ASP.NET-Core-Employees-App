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
            if(ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                TempData["added"] = "Department added successfuly";
                return RedirectToAction("Index");
            }
            return View(department);
            
        }

        public IActionResult Edit(int Id)
        {
            var department = db.Departments.Where(dep => dep.DepartmentID == Id).First();
            return View("Create",department);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Department department)
        {
            var data = db.Departments.Where(dep => dep.DepartmentID == Id).First();
            if (ModelState.IsValid)
            {
                data.DepartmentName = department.DepartmentName;
                data.DepartmentAbbr = department.DepartmentAbbr;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", data);
        }

        public IActionResult Delete(int Id)
        {
            var department = db.Departments.Where(dep => dep.DepartmentID == Id).First();
            db.Departments.Remove(department);
            db.SaveChanges();
            TempData["removed"] = "Department Removed";
            return RedirectToAction("Index");
        }
    }
}