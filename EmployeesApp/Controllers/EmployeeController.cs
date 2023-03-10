using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Models;

namespace EmployeesApp.Controllers
{
    public class EmployeeController : Controller
    {
        //create dbcontext object
        HRDatabaseContext db = new HRDatabaseContext();
        public IActionResult Index()
        
        {
            List<Employee> employees = db.Employees.ToList(); 
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            // if data in the model is valid then it will post it to the database
            // else it will fetch the departments and return the create view
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departments = db.Departments.ToList();
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var data = db.Employees.Where(e => e.EmployeeID == Id).FirstOrDefault();
            ViewBag.departments = db.Departments.ToList();
            return View("Create",data);
        }
    }
}
