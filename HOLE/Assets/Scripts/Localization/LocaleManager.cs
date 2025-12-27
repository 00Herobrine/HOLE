using System.Text.Json;
using HOLE.Assets.Scripts.Utils;

namespace HOLE.Assets.Scripts.Localization;

public static class LocaleManager
{
    //public static string DefaultLocale = "en_US";
    private static Locale _currentLocale;

    public static Action<Locale>? LocalizationUpdatedEvent;
    public static string LocalesPath => Launcher.Config.Paths.Locales;
    
    public static Locale GetCurrentLocale() => _currentLocale;
    public static Locale? GetLocale(string localeCode)
    {
        if(!FileManagement.DirectoryCheck(LocalesPath)) 
            return null;
        
        string localeFile = Path.Combine(LocalesPath, $"{localeCode}.json");
        if (!File.Exists(localeFile)) 
            return null;
        
        string localeText = File.ReadAllText(localeFile);
        return JsonSerializer.Deserialize<Locale?>(localeText);
    }
    public static void SetLang(string localeCode)
    {
        Locale? locale = GetLocale(localeCode);
        if (locale == null) 
            return;
        
        _currentLocale = locale.Value;
        LocalizationUpdatedEvent?.Invoke(locale.Value);
    }
    
}