using Microsoft.AspNetCore.Mvc;

namespace MPA201AdminPanel.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
