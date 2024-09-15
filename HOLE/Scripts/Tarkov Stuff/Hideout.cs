using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
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
            PropertyInfo? propery = typeof(T).GetProperty(propertyName) ?? throw new ArgumentException($"Property '{propertyName}' not found in type '{typeof(T)}'.");
            RangeAttribute? attribute = propery.GetCustomAttribute<RangeAttribute>() ?? throw new InvalidOperationException($"Property '{propertyName}' does not have a RangeAttribute.");
            T[] minMax = [(T) attribute.Minimum, (T) attribute.Maximum];
            return minMax;
        }
    }
}
