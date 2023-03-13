using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
