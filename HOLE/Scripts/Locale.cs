using System.Text.Json;

namespace HOLE.Scripts
{
    public struct Locale
    {
        private Dictionary<string, string>? _locale = new();

        public Locale(string path)
        {
            string json = File.ReadAllText(path);
            _locale = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }

        public string FromID(string ID) => _locale?[ID] ?? $"ID({ID}) NOT FOUND";
    }
}
