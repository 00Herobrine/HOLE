using HOLE.Scripts;
using System.Diagnostics;
using System.Text.Json;

namespace HOLE
{
    public enum ItemType { ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS,
        AMMO, MAGAZINE, GRENADES, FOOD, CONTAINERS, ITEMS, KNIVES, MAPS, MEDICALS, MODS, MONEY }
    internal static class TarkovCache
    {
        public static Dictionary<string, TarkovItem> Items { get; private set; } = new();
        public static Dictionary<string, TarkovQuest> Quests { get; private set; } = new();
        public static string? Directory { get; private set; }
        internal static void Initialize(Instance instance)
        {
            Directory = instance.Directory;
            Debug.WriteLine("Initializing " + instance.GlobalLocale);
            Dictionary<string, string>? itemsLocale = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(instance.GlobalLocale));
            if(itemsLocale != null) CacheItems(itemsLocale);
            Dictionary<string, string>? questsLocale = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(instance.ServerLocale));
            if (questsLocale != null) CacheQuests(questsLocale); 
        }
        private static void CacheItems(Dictionary<string, string> itemsLocale)
        {
            foreach(var item in itemsLocale)
            {
                string[] args = item.Key.Split(" ");
                if (args.Length <= 1) continue;
                string id = args[0];
                AddToItems(id, args[1], item.Value);
            }
        }
        private static void AddToItems(string id, string category, string entry)
        {
            TarkovItem item = Items.TryGetValue(id, out TarkovItem value) ? value : new TarkovItem(id);
            switch(category)
            {
                case "Name":
                    item.Name = entry;
                    break;
                case "ShortName":
                    item.ShortName = entry;
                    break;
                case "Description":
                    item.Description = entry;
                    break;
            }
            Debug.WriteLine($"Set {category} to {entry} for ID: {id}");
            if (!Items.ContainsKey(id)) Debug.WriteLine($"Added Item {item.Name} ({id})");
            Items[id] = item;
        }
        private static void CacheQuests(Dictionary<string, string> questsLocale)
        {
            foreach(var item in questsLocale)
            {
                string[] args = item.Key.Split(" ");
                if (args.Length <= 1) continue;
                string id = args[0];
                AddToQuests(id, args[1], item.Value);
            }
        }
        private static void AddToQuests(string id, string category, string entry)
        {
            TarkovQuest quest = Quests.TryGetValue(id, out TarkovQuest value) ? value : new TarkovQuest(id);
            switch (category)
            {
                case "name":
                    quest.name = entry;
                    break;
                case "description":
                    quest.description = entry;
                    break;
                case "failMessageText":
                    quest.failMessageText = entry;
                    break;
                case "successMessageText":
                    quest.successMessageText = entry;
                    break;
                case "acceptPlayerMessage":
                    quest.acceptMessageText = entry;
                    break;
                case "declinePlayerMessage":
                    quest.declineMessageText = entry;
                    break;
                case "completePlayerMessage":
                    quest.completeMessageText = entry;
                    break;
            }
            Quests[id] = quest;
        }
    }

    internal struct TarkovItem(string ID)
    {
        public readonly string ID { get; } = ID;
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }

    internal struct TarkovQuest(string ID)
    {
        public readonly string ID { get; } = ID;
        public string name { get; set; }
        public string description { get; set; }
        public string failMessageText { get; set; }
        public string successMessageText { get; set; }
        public string acceptMessageText { get; set; }
        public string declineMessageText { get; set; }
        public string completeMessageText { get; set; }
    }
}
