using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TARge25Shop.Core.ServiceInterface;

namespace TARge25Shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeatherController(IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                ModelState.AddModelError("", "Sisesta linna nimi");
                return View();
            }

            var result = await _openWeatherServices.GetWeatherAsync(cityName);

            if (result == null)
            {
                ModelState.AddModelError("", "Linna ei leitud või API päring ebaõnnestus.");
                return View();
            }

            return View(result);
        }
    }
}