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
            Instance? instance = e.Instance;
            if (instance == null) return;
            string json = File.ReadAllText(((Instance)instance).ProductionPath ?? "");
            Recipe[]? recipes = JsonSerializer.Deserialize<Recipe[]>(json);
            if (recipes != null) Recipes = recipes;
            foreach(Recipe recipe in Recipes)
            {
                Logger.Log(recipe.ToString());
            }
            Logger.Log($"Cached {Recipes.Length} Recipes.");
        }
    }

    public struct Recipe
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("_id")]
        public string ID { get; set; }
        [JsonPropertyName("areaType")]
        public Module AreaType { get; set; }
        [JsonPropertyName("requirements")]
        public RecipeRequirement[] Requirements { get; set; }
        [JsonPropertyName("productionTime")]
        public int ProductionTime { get; set; }
        [JsonPropertyName("needFuelForAllProductionTime")]
        public bool NeedFuelForAllProductionTime { get; set; }
        [JsonPropertyName("locked")]
        public bool Locked { get; set; }
        [JsonPropertyName("endProduct")]
        public string EndProduct { get; set; }
        [JsonPropertyName("continuous")]
        public bool Continuous { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("productionLimitCount")]
        public int ProductionLimitCount { get; set; }
        [JsonPropertyName("isEncoded")]
        public bool IsEncoded { get; set; }
        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? TarkovCache.GetItem(EndProduct)?.Name ?? ID : Name;
        }
        //public override string ToString() => Name ?? Id;
    }

    public struct RecipeRequirement
    {
        [JsonPropertyName("areaType")]
        public Module? AreaType { get; set; }
        [JsonPropertyName("requiredLevel")]
        public int? RequiredLevel { get; set; }
        [JsonPropertyName("count")]
        public int? Count { get; set; }
        [JsonPropertyName("isFunctional")]
        public bool? IsFunctional { get; set; }
        [JsonPropertyName("isEncoded")]
        public bool? IsEncoded { get; set; }
        [JsonPropertyName("questId")]
        public string? QuestId { get; set; }
        [JsonPropertyName("templateId")]
        public string? TemplateId { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        //public string ID => TemplateId ?? QuestId ?? $"{(int?)AreaType}" ?? Type;
        public readonly string RequirementID => TemplateId ?? QuestId ?? $"{(int?)AreaType}";
        public override string ToString()
        {
            return TarkovCache.GetItem(TemplateId ?? "")?.Name ?? TarkovCache.GetQuest(QuestId ?? "")?.Name ?? AreaType?.GetDescription() ?? Type;
        }
    }
}
