namespace HOLE.Scripts.Misc
{
    public class StringAttribute(string URL) : Attribute
    {
        public readonly string Value = URL;
        public bool Validate(string inputURL) => inputURL.StartsWith(Value);
        public string GetURL() => Value;
    }
    public static class StringAttributeExtensions
    {
        public static StringAttribute? GetStringAttribute(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field == null) return null;
            return (StringAttribute?) Attribute.GetCustomAttribute(field, typeof(StringAttribute));
        }
        public static bool Validate(this StringAttribute attribute, string inputURL)
        {
            return inputURL.StartsWith(attribute.Value);
        }
    }
}
