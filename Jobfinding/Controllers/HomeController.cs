using Microsoft.AspNetCore.Mvc;

namespace Jobfinding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
