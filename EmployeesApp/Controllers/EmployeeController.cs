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
    }
}
