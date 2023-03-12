using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Controllers
{
    public class EmployeeController : Controller
    {
        //create dbcontext object
        HRDatabaseContext db = new HRDatabaseContext();
        public IActionResult Index()
        
        {
            // include is called eager loading which can fetch the related data from other models
            List<Employee> employees = db.Employees.Include(emp => emp.Department).ToList(); 
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

        [HttpPost]
        public IActionResult Edit(int Id, Employee employee)
        {
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                var emp = db.Employees.Where(e => e.EmployeeID == Id).FirstOrDefault();
                emp.EmployeeName = employee.EmployeeName;
                emp.DOB = employee.DOB;
                emp.HiringDate = employee.HiringDate;
                emp.GrossSalary = employee.GrossSalary;
                emp.NetSalary = employee.NetSalary;
                emp.DepartmentId = employee.DepartmentId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departments = db.Departments.ToList();
            return View("Create");
        }

        public IActionResult Delete(int Id)
        {
            var employee = db.Employees.Where(e => e.EmployeeID == Id).First();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
