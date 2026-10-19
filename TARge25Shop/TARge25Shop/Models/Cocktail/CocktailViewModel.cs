namespace TARge25Shop.Models.Cocktail
{
    public class CocktailViewModel
    {
        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        public string? Instructions { get; set; }

        public List<string> Ingredients { get; set; } = new();
    }
}