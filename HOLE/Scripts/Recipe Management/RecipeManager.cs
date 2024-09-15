using HOLE.Scripts.Tarkov_Stuff;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HOLE.Scripts
{
    internal static class RecipeManager
    {
        public static Recipe[] Recipes { get; private set; } = [];

        public static void Initialize()
        {
            InstanceManager.InstanceChangedEvent += CacheRecipe;
        }

        private static void CacheRecipe(object? sender, InstanceEventArgs e)
        {
            AkiInstance? instance = e.Instance;
            if (instance == null) return;
            string json = File.ReadAllText(((AkiInstance)instance).ProductionPath ?? "");
            Recipe[]? recipes = JsonSerializer.Deserialize<Recipe[]>(json);
            if (recipes != null) Recipes = recipes;
            Logger.Log($"Cached {Recipes.Length} Recipes.");
        }
    }
}
