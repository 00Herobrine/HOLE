using System.Text.Json;

namespace HOLE.Scripts
{
    internal static class RecipeManager
    {
        public static Dictionary<string, Recipe> Recipes = new();
        public static void Initialize()
        {
            CacheRecipes();
        }

        private static void CacheRecipes()
        {
            Recipes.Clear();
            Instance? instance = InstanceManager.SelectedInstance;
            string json = File.ReadAllText(instance?.HideoutPath ?? "");
            Dictionary<string, Recipe>? recipes = JsonSerializer.Deserialize<Dictionary<string, Recipe>>(json);
            if (recipes != null) Recipes = recipes;
            Logger.Log($"Cached {Recipes.Count} Recipes.");
        }
        private static void CacheRecipe(Recipe recipe)
        {
            Recipes.Add(recipe.Id, recipe);
        }
    }

    public struct Recipe
    {
        public string Id { get; set; }
        public int AreaType { get; set; }
        public List<RecipeRequirement> Requirements { get; set; }
        public int ProductionTime { get; set; }
        public bool NeedFuelForAllProductionTime { get; set; }
        public bool Locked { get; set; }
        public string EndProduct { get; set; }
        public bool Continuous { get; set; }
        public int Count { get; set; }
        public int ProductionLimitCount { get; set; }
        public bool IsEncoded { get; set; }
    }

    public struct RecipeRequirement
    {
        public int? AreaType { get; set; }
        public int? RequiredLevel { get; set; }
        public string TemplateId { get; set; }
        public int? Count { get; set; }
        public bool? IsFunctional { get; set; }
        public bool? IsEncoded { get; set; }
        public string QuestId { get; set; }
        public string Type { get; set; }
    }
}
