using System.Diagnostics;
using System.Text.Json;

namespace HOLE.Assets.Scripts
{
    public class UIElement // turn this abstract for text support
    {
        public required string ElementName;
        public required string ElementID;
        public Button Button;
        public Control control;
    }
    public class UISettings
    {
        public UIElement[] LauncherButtons; // Buttons to auto-initialize in the IconManager (in theory)
    }
    public static class UIManager
    {
        public static string UISettingsPath => Launcher.UISettingsPath;
        public static UISettings UISettings { get; private set; } = new();

        private static List<UIElement> _buttonLookup = new();
        //private static Dictionary<string, List<UIElement>> _buttonLookup = new(); // Form Name, LauncherButton
        public static readonly string[] allowedImageTypes = [".png", ".jpg", ".jpeg", ".gif"];

        public static UISettings GetLauncherSettings(bool reload = false)
        {
            if (!Path.Exists(UISettingsPath))
            {
                SetUISettings(new());
            }
            if (UISettings == null || reload)
            {
                string json = File.ReadAllText(UISettingsPath);
                UISettings settings = JsonSerializer.Deserialize<UISettings>(json) ?? new UISettings();
                UISettings = settings;
            }
            return UISettings;
        }

        public static void RegisterUIElements(Form form)
        {
            foreach (Control control in form.Controls)
            {
                foreach (UIElement element in _buttonLookup)
                {
                    if (!string.Equals(element.ElementName, control.Name, StringComparison.Ordinal)) continue;
                    element.control = control;
                }
            }
        }

        private static void StoreLookups()
        {
            foreach (var launcherButton in UISettings.LauncherButtons)
            {
                string formName = launcherButton.ElementName.Split("/").First();
                _buttonLookup.Add(launcherButton);
            }
        }
        
        private static void SetUISettings(UISettings settings)
        {
            UISettings = settings;
        }

    }
}
