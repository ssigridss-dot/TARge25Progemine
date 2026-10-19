using System.Text.Json;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;

namespace TARge25Shop.ApplicationServices.Services
{
    public class CocktailServices : ICocktailServices
    {
        private readonly HttpClient _httpClient;

        public CocktailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CocktailRootDto> CocktailResultHttpClient()
        {
            var response = await _httpClient.GetAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita"
            );

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var cocktail = JsonSerializer.Deserialize<CocktailRootDto>(
                json, options
            );

            return cocktail
                ?? throw new Exception("Cocktail API ei tagastanud andmeid.");
        }
    }
}