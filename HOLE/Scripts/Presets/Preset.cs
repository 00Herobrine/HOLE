namespace HOLE.Scripts.Presets
{
    public abstract class Preset : IPresetInfo
    {
        public PresetInfo Info { get; set; }
        public bool Replace { get; internal set; } = false;
    }

    public interface IPresetInfo
    {
        public PresetInfo Info { get; }
    }

    /*    public interface IPresetInfo
        {
            public string? Name { get; }
            public string LauncherVersion { get; }
            public bool Replace { get; }
        }*/

    public struct PresetInfo
    {
        public PresetValue<string?> Name { get; set; } // Custom name for settings file to display
        public PresetValue<string?> Author { get; set; }
        public PresetValue<string> LauncherVersion { get; set; }
        public PresetValue<string> AkiVersion { get; set; }
        public PresetValue<bool> Replace { get; set; }
    }

    public struct PresetValue<T>
    {
        public T Value { get; set; }
        public bool Replace { get; set; }
    }
}
