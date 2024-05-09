using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HOLE.Scripts.Misc;
using System.Numerics;
using System.Reflection;

namespace HOLE.Scripts.Tarkov_Stuff
{
    public struct Hideout
    {
        public Area[] Areas { get; set; }
    }

    public struct Area
    {
        public bool active { get; set; }
        public int completeTime { get; set; } // UTX time maybe?
        public bool constructing { get; set; }
        public string lastRecipe { get; set; }
        public int level { get; set; }
        public bool passiveBonusesEnabled { get; set; }
        public Module type { get; set; }
    }
    public enum Module
    {
        [Description("Vents"), Range(1, 3)]
        VENTS = 0,
        [Description("Security"), Range(1, 3)]
        SECURITY = 1,
        [Description("Lavoratory"), Range(1, 3)]
        LAVORATORY = 2,
        [Description("Stash"), Range(1, 4)]
        STASH = 3,
        [Description("Generator"), Range(1, 3)]
        GENERATOR = 4,
        [Description("Heating"), Range(1, 3)]
        HEATING = 5,
        [Description("Water Collector"), Range(1, 3)]
        WATER = 6,
        [Description("Medstation"), Range(1, 3)]
        MEDICAL = 7,
        [Description("Nutrition Unit"), Range(1, 3)]
        NUTRITION = 8,
        [Description("Rest Space"), Range(1, 3)]
        RESTSPACE = 9,
        [Description("Workbench"), Range(1, 3)]
        WORKBENCH = 10,
        [Description("Intelligence Center"), Range(1, 3)]
        INTELLIGENCE = 11,
        [Description("Shooting Range"), Range(1, 3)]
        SHOOTINGRANGE = 12,
        [Description("Library"), Range(1, 1)]
        LIBRARY = 13,
        [Description("Scav Case"), Range(1, 1)]
        SCAVBOX = 14,
        [Description("Illumination"), Range(1, 3)]
        LIGHTING = 15,
        [Description("Place of Fame"), Range(1, 1)]
        FAME = 16,
        [Description("Air Filtering Unit"), Range(1, 1)]
        AIRFILTER = 17,
        [Description("Solar Power"), Range(1, 1)]
        SOLAR = 18,
        [Description("Booze Generator"), Range(1, 1)]
        BOOZEGENERATOR = 19,
        [Description("Bitcoin Farm"), Range(1, 3)]
        BTC = 20,
        [Description("Christmas Tree"), Range(1, 1)]
        CHRISTMAS = 21,
        [Description("Broken Wall"), Range(1, 6)]
        BROKENWALL = 22,
        [Description("Gym"), Range(1, 2)]
        GYM = 23
    }
    public static class ModuleExtension
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field == null) return "";
            return ((DescriptionAttribute?) Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)))?.Description ?? "";
        }
        public static int[] GetRange(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetCustomAttribute<RangeAttribute>();
            if (field == null) return [0, 0];
            else return [(int)field.Minimum, (int)field.Maximum];
        }
        public static T[] GetRangeAttribute<T>(string propertyName)
        {
            PropertyInfo? propery = typeof(T).GetProperty(propertyName);
            if (propery == null) throw new ArgumentException($"Property '{propertyName}' not found in type '{typeof(T)}'.");
            RangeAttribute? attribute = propery.GetCustomAttribute<RangeAttribute>();
            if (attribute == null) throw new InvalidOperationException($"Property '{propertyName}' does not have a RangeAttribute.");
            T[] minMax = new T[2];
            minMax[0] = (T) attribute.Minimum;
            minMax[1] = (T) attribute.Maximum;
            return minMax;
        }
    }
}
