namespace HOLE.Assets.Scripts.Localization;

public struct Locale(string langCode, MessageLocales messageLocales, UILocales uiLocales)
{
    public string LangCode = langCode; // en_US, en_UK, ru_RU, es_MX
    public MessageLocales MessageLocales = messageLocales;
    public UILocales UI = uiLocales;
}

public struct MessageLocales
{
    public LauncherLocale Launcher;
    public FileManagementLocale FileManagement;
    public DialogBoxLocale Dialog; // think windows handles this automatically
    
    public struct ModManagerLocale
    {
        public string DownloadsFolderNotFound;
        public string DownloadsFolderCreated;
        public string ModsFolderNotFound;
        public string ModsFolderCreated;
        public string ModsFolderJunctionCreated;
        public string ModsFolderJunctionDeleted;
        public string SPTQuerySuccess;
        public string SPTQueryFailed;
        public string DownloadFailed;
        public string DownloadSuccess;
        public string DownloadTokenFailed;
        public string FormatUrlSuccess;
        public string FormatUrlFailed;
        public string DetermineUrlOriginSuccess;
        public string DetermineUrlOriginFailed;
    }

    public struct FileManagementLocale
    {
        public string? JunctionSourceDirectoryDoesntExist;

        public FileManagementLocale()
        {
            
        }
    }

    public struct LauncherLocale
    {
        public string ThemesFolderFound;
        public string ThemesFolderNotFound;
        public string ThemesFolderCreated;
        public string ConfigFileFound;
        public string ConfigFileNotFound;
        public string ConfigFileCreated;
        public string ConfigFileWriteSuccess;
        public string ConfigFileWriteFailed;
        public string ConfigFileParseSuccess;
        public string ConfigFileParseFailed;
    }

    public struct DialogBoxLocale
    {
        public string? Error;
        public string? Info;
        public string? Warning;
        public string? Question;
        public string? Ok;
        public string? Cancel;
        public string? Yes;
        public string? No;
        public string? Abort;
        public string? Retry;
        public string? Ignore;
        public string? TryAgain;
        public string? Continue;
    }
}

public struct UIElement
{
    public string? Text;
    public string? ToolTip;
    public string? Image;
}

public struct UILocales
{
    public LauncherElements Launcher;
    public ModManagerElements ModManager;
    
    public struct LauncherElements
    {
        public UIElement AddInstanceButton;
        public UIElement AddFikaButton;
        public UIElement FoldersButton;
        public UIElement SettingsButton;
        public UIElement UpdateButton;
        public UIElement CatButton;
        public UIElement LaunchButton;
        public UIElement KillButton;
        public UIElement EditButton;
        public UIElement FolderButton;
        public UIElement ExportButton;
        public UIElement CopyButton;
        public UIElement DeleteButton;
        public UIElement CreateShortcutButton;
        public UIElement DownloadModsButton;
    }
    
    
    public struct ModManagerElements
    {
        public UIElement SortLabel;
        public UIElement VersionLabel;
        public UIElement FilterNameCheckBox;
        public UIElement FilterDescriptionCheckBox;
        public UIElement SearchBarPlaceHolder;
        public UIElement SearchButton;
        public UIElement SelectButton;
        public UIElement ConfirmButton;
        public UIElement CancelButton;
    }
}
