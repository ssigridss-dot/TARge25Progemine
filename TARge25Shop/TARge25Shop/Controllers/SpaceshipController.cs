using Microsoft.AspNetCore.Mvc;

namespace TARge25Shop.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
