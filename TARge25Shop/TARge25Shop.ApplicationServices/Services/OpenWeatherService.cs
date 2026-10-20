using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace TARge25Shop.ApplicationServices.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenWeatherService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<OpenWeatherViewModel?> GetWeatherAsync(string city)
        {
            string? apiKey =
                _configuration["OpenWeather:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException(
                    "OpenWeather API võti puudub.");
            }

            string url =
                "https://api.openweathermap.org/data/2.5/weather" +
                $"?q={Uri.EscapeDataString(city)}" +
                $"&appid={Uri.EscapeDataString(apiKey)}" +
                "&units=metric&lang=et";

            using HttpResponseMessage response =
                await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<OpenWeatherViewModel>(
                json);
        }
    }
}
