using Microsoft.AspNetCore.Mvc;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Models.Cocktail;

namespace TARge25Shop.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailServices _cocktailServices;

        public CocktailController(ICocktailServices cocktailServices)
        {
            _cocktailServices = cocktailServices;
        }

        public async Task<IActionResult> Index()
        {
            return await Cocktail();
        }

        [HttpGet]
        public async Task<IActionResult> Cocktail()
        {
            var result =
                await _cocktailServices.CocktailResultHttpClient();

            var drink = result.Drinks?.FirstOrDefault();

            if (drink == null)
            {
                return NotFound("Margarita kokteili ei leitud.");
            }

            CocktailViewModel vm = new()
            {
                Name = drink.Name,
                ImageUrl = drink.ImageUrl,
                Instructions = drink.Instructions,
                Ingredients = new[]
                {
                    drink.Ingredient1,
                    drink.Ingredient2,
                    drink.Ingredient3,
                    drink.Ingredient4,
                    drink.Ingredient5,
                    drink.Ingredient6,
                    drink.Ingredient7,
                    drink.Ingredient8,
                    drink.Ingredient9,
                    drink.Ingredient10,
                    drink.Ingredient11,
                    drink.Ingredient12,
                    drink.Ingredient13,
                    drink.Ingredient14,
                    drink.Ingredient15
                }
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x!)
                .ToList()
            };

            return View("Cocktail", vm);
        }
    }
}