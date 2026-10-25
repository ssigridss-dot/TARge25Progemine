using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;

namespace TARge25Shop.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "43b8f2310550b2d16ad26ec5101a9e87";

        public OpenWeatherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OpenWeatherDto> GetWeatherAsync(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={ApiKey}&units=metric";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<OpenWeatherDto>(url);
                return response;
            }
            catch
            {
                return null; // Kui linna ei leita või tekib viga
            }
        }
    }
}