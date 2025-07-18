namespace HOLE.Assets.Scripts;

public struct UIElements
{
    public LauncherElements Launcher;
}

public struct LauncherElements
{
    public string AddInstanceButton;
    public string AddInstanceTooltip;
    public string AddFikaButton;
    public string AddFikaTooltip;
    public string FoldersButton;
    public string FoldersTooltip;
    public string SettingsButton;
    public string SettingsTooltip;
    public string UpdateButton;
    public string UpdateTooltip;
    public string CatButton;
    public string CatTooltip;
    public string LaunchButton;
    public string LaunchTooltip;
    public string KillButton;
    public string KillTooltip;
    public string EditButton;
    public string EditTooltip;
    public string FolderButton;
    public string FolderTooltip;
    public string ExportButton;
    public string ExportTooltip;
    public string CopyButton;
    public string CopyTooltip;
    public string DeleteButton;
    public string DeleteTooltip;
    public string CreateShortcutButton;
    public string CreateShortcutTooltip;
    public string DownloadModsButton;
    public string DownloadModsTooltip;
}

public struct DownloaderElements
{
    public string SortLabel;
    public string VersionLabel;
    public string FilterNameCheck;
    public string FilterDescriptionCheck;
    public string VersionBoxTooltip;
    public string SearchBarPlaceHolder;
    public string SearchBarTooltip;
    public string SearchButton;
    public string SearchButtonTooltip;
    public string SelectButton;
    public string SelectButtonTooltip;
    public string ConfirmButton;
    public string ConfirmButtonTooltip;
    public string CancelButton;
    public string CancelButtonTooltip;
}

public struct Messages
{
    public string ThemesNotFound;
    public string ThemesFound;
    public string ConfigCreationSuccess;
    public string ConfigCreationFailed;
    public string SPTModsQuerySuccess;
    public string SPTModsQueryFailed;
    public string SPTModsParseSuccess;
    public string SPTModsParseFailed;
    public string ModDownloadFailed;
    public string ModDownloadSuccess;
    public string ModDownloadTokenFailed;
    public string FormatUrlSuccess;
    public string FormatUrlFailed;
    public string DetermineUrlOriginSuccess;
    public string DetermineUrlOriginFailed;
}

public struct LangFile
{
    public string Language;
    public Messages Messages;
    public UIElements UI;
}

public static class Localization
{
    private static LangFile? _currentLang;
    public static Action<LangFile>? LocalizationUpdatedEvent;
    public static string LocalesPath => Launcher.Config.Paths.Locales;
    
    public static void SetLang(string langCode)
    {
        
        //LocalizationUpdatedEvent?.Invoke();
    }
}