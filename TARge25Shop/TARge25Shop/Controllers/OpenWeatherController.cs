
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TARge25Shop.ApplicationServices.Services;

namespace TARge25Shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly OpenWeatherService _openWeatherService;

        public OpenWeatherController(
            OpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public OpenWeatherService Get_openWeatherService1()
        {
            return _openWeatherService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city, OpenWeatherService _openWeatherService1)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                ViewBag.Error = "Palun sisesta linna nimi.";
                return View();
            }

            try
            {
                var weather =
                    await _openWeatherService.GetWeatherAsync(city);

                if (weather == null)
                {
                    ViewBag.Error = "Ilmaandmeid ei õnnestunud lugeda.";
                    return View();
                }

                return View(weather);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error =
                    "Ilma laadimine ebaõnnestus. " +
                    "Kontrolli linna nime, API võtit ja internetiühendust.";

                return View();
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
