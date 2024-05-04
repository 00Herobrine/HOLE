namespace HOLE.Scripts.Misc
{
    public class DisplayNameAttribute : Attribute, IDisplayNameAttribute
    {
        public string DisplayName { get; }
        public string Value { get; }
        public DisplayNameAttribute(IDisplayNameAttribute attribute)
        {
            DisplayName = attribute.DisplayName;
            Value = attribute.Value;
        }
        public DisplayNameAttribute(string displayName, string value)
        {
            DisplayName = displayName;
            Value = value;
        }
    }
    public interface IDisplayNameAttribute
    {
        public string DisplayName { get; }
        public string Value { get; }
    }
    public static class DisplayNameAttributeExtensions
    {
        public static IDisplayNameAttribute? GetDisplayNameAttribute(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field == null) return null;
            return (IDisplayNameAttribute?)Attribute.GetCustomAttribute(field, typeof(IDisplayNameAttribute));
        }
    }
}
