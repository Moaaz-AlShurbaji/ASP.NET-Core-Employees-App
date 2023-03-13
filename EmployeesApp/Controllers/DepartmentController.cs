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
    }
}