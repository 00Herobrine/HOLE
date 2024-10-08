﻿using HOLE.Scripts;
using System.Text.Json;

namespace HOLE
{
    public enum ItemType { ARMOR, BACKPACKS, CLOTHING, HEADPHONES, HELMETS, RIGS, FIREARMS,
        AMMO, MAGAZINE, GRENADES, FOOD, CONTAINERS, ITEMS, KNIVES, MAPS, MEDICALS, MODS, MONEY }
    public static class TarkovCache
    {
        public static Dictionary<string, TarkovItem> Items { get; private set; } = [];
        public static Dictionary<string, TarkovQuest> Quests { get; private set; } = [];
        public static string? Directory { get; private set; }

        public static void Initialize() 
        {
            InstanceManager.InstanceChangedEvent += LoadCache;
        }

        private static void LoadCache(object? sender, InstanceEventArgs e)
        {
            if (e.Instance == null) return;
            LoadCache((AkiInstance)e.Instance);
        }

        public static void LoadCache(AkiInstance instance)
        {
            Directory = instance.Directory;
            Logger.Log("Initializing " + instance.GlobalLocale);
            Dictionary<string, string>? locales = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(instance.GlobalLocale));
            if (locales != null) CacheLocale(locales);
        }

        public static TarkovItem? GetItem(string id)
        {
            Items.TryGetValue(id, out TarkovItem item);
            return item;
        }
        public static TarkovQuest? GetQuest(string id)
        {
            Quests.TryGetValue(id, out TarkovQuest quest);
            return quest;
        }

        private static void CacheLocale(Dictionary<string, string> locales)
        {
            foreach(var locale in locales)
            {
                string[] args = locale.Key.Split(" ");
                if (args.Length <= 1) continue;
                string id = args[0];
                string category = args[1];
                switch(category)
                {
                    case "Name":
                    case "ShortName":
                    case "Description":
                        CacheItem(id, category, locale.Value);
                        break;
                    case "name":
                    case "description":
                    case "failMessageText":
                    case "successMessageText":
                    case "acceptPlayerMessage":
                    case "declinePlayerMessage":
                    case "completePlayerMessage":
                        CacheQuest(id, category, locale.Value);
                        break;
                }
            }
            Logger.Log($"Cached: {Items.Count} Items & {Quests.Count} Quests");
        }
        private static void CacheItem(string id, string category, string value)
        {
            TarkovItem item = Items.TryGetValue(id, out TarkovItem ti) ? ti : new TarkovItem(id);
            switch(category)
            {
                case "Name":
                    item.Name = value;
                    break;
                case "ShortName":
                    item.ShortName = value;
                    break;
                case "Description":
                    item.Description = value;
                    break;
            }
            Items[id] = item;
        }
        private static void CacheQuest(string id, string category, string value)
        {
            TarkovQuest quest = Quests.TryGetValue(id, out TarkovQuest ti) ? ti : new TarkovQuest(id);
            switch (category)
            {
                case "name":
                    quest.Name = value;
                    break;
                case "description":
                    quest.Description = value;
                    break;
                case "failMessageText":
                    quest.FailMessageText = value;
                    break;
                case "successMessageText":
                    quest.SuccessMessageText = value;
                    break;
                case "acceptPlayerMessage":
                    quest.AcceptMessageText = value;
                    break;
                case "declinePlayerMessage":
                    quest.DeclineMessageText = value;
                    break;
                case "completePlayerMessage":
                    quest.CompleteMessageText = value;
                    break;
            }
            Quests[id] = quest;
        }
    }

    public struct TarkovItem(string ID)
    {
        public readonly string ID { get; } = ID;
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }

    public struct TarkovQuest(string ID)
    {
        public readonly string ID { get; } = ID;
        public string Name { get; set; }
        public string Description { get; set; }
        public string FailMessageText { get; set; }
        public string SuccessMessageText { get; set; }
        public string AcceptMessageText { get; set; }
        public string DeclineMessageText { get; set; }
        public string CompleteMessageText { get; set; }
    }
}
