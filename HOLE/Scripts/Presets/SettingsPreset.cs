namespace HOLE.Scripts.Presets
{
    internal class SettingsPreset : Preset
    {
        #region Paths
        public PresetValue<string> LauncherDataPath { get; set; }
        public PresetValue<string> InstancesPath { get; set; }
        public PresetValue<string> ModsPath { get; set; }
        public PresetValue<string> DownloadingModsPath { get; set; }
        public PresetValue<string> BackupsPath { get; set; }
        public PresetValue<string> PresetsPath { get; set; }
        public PresetValue<string> IconPacksPath { get; set; }
        #endregion
    }
}