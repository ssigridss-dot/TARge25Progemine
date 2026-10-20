
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TARge25Shop.Models
{
    public class OpenWeatherViewModel
    {
        [JsonPropertyName("name")]
        public string City { get; set; } = "";

        [JsonPropertyName("main")]
        public OpenWeatherMain Main { get; set; } = new();

        [JsonPropertyName("weather")]
        public List<OpenWeatherDescription> Weather { get; set; } = new();

        [JsonPropertyName("wind")]
        public OpenWeatherWind Wind { get; set; } = new();
    }

    public class OpenWeatherMain
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class OpenWeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }

    public class OpenWeatherWind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }
}
