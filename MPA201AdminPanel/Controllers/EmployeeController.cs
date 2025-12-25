using Microsoft.AspNetCore.Mvc;

namespace MPA201AdminPanel.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
