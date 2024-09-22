using SharpHook.Native;

namespace EyecraftTech.Devices
{
    public static class TEST_Shortcuts
    {
        public static readonly List<IAction> Actions = [];

        // Media Controls
        public static readonly ShortcutAction PlayPause = new("Media Play/Pause", KeyCode.VcMediaPlay);
        public static readonly ShortcutAction NextTrack = new("Media Next Track", KeyCode.VcMediaNext);
        public static readonly ShortcutAction PreviousTrack = new("Media Previous Track", KeyCode.VcMediaPrevious);
        public static readonly ShortcutAction StopPlayback = new("Media Stop", KeyCode.VcMediaStop);
        public static readonly ShortcutAction VolumeUp = new("Volume Up", KeyCode.VcVolumeUp);
        public static readonly ShortcutAction VolumeDown = new("Volume Down", KeyCode.VcVolumeDown);
        public static readonly ShortcutAction VolumeMute = new("Volume Mute", KeyCode.VcVolumeMute);

        // General Shortcuts
        public static readonly ShortcutAction Copy = new("Copy", KeyCode.VcLeftControl, KeyCode.VcC);
        public static readonly ShortcutAction Cut = new("Cut", KeyCode.VcLeftControl, KeyCode.VcX);
        public static readonly ShortcutAction Paste = new("Paste", KeyCode.VcLeftControl, KeyCode.VcV);
        public static readonly ShortcutAction Undo = new("Undo", KeyCode.VcLeftControl, KeyCode.VcZ);
        public static readonly ShortcutAction Redo = new("Redo", KeyCode.VcLeftControl, KeyCode.VcY);
        public static readonly ShortcutAction SelectAll = new("Select All", KeyCode.VcLeftControl, KeyCode.VcA);
        public static readonly ShortcutAction Save = new("Save", KeyCode.VcLeftControl, KeyCode.VcS);
        public static readonly ShortcutAction Print = new("Print", KeyCode.VcLeftControl, KeyCode.VcP);
        public static readonly ShortcutAction NewWindow = new("New Window", KeyCode.VcLeftControl, KeyCode.VcN);
        public static readonly ShortcutAction CloseWindow = new("Close Window", KeyCode.VcLeftControl, KeyCode.VcW);
        public static readonly ShortcutAction SwitchApps = new("Switch App", KeyCode.VcLeftAlt, KeyCode.VcTab);
        public static readonly ShortcutAction CloseApp = new("Close App", KeyCode.VcLeftAlt, KeyCode.VcF4);
        public static readonly ShortcutAction ShowProperties = new("Properties", KeyCode.VcLeftAlt, KeyCode.VcEnter);
        public static readonly ShortcutAction WindowMenu = new("Alt+Space", KeyCode.VcLeftAlt, KeyCode.VcSpace);
        public static readonly ShortcutAction ShowDesktop = new("Show Desktop", KeyCode.VcLeftMeta, KeyCode.VcD);
        public static readonly ShortcutAction LockPC = new("Lock PC", KeyCode.VcLeftMeta, KeyCode.VcL);
        public static readonly ShortcutAction MinimizeAll = new("Minimize All", KeyCode.VcLeftMeta, KeyCode.VcM);
        public static readonly ShortcutAction RestoreWindows = new("Restore Windows", KeyCode.VcLeftMeta, KeyCode.VcLeftShift, KeyCode.VcM);
        public static readonly ShortcutAction OpenExplorer = new("Open Explorer", KeyCode.VcLeftMeta, KeyCode.VcE);
        public static readonly ShortcutAction RunDialog = new("Run", KeyCode.VcLeftMeta, KeyCode.VcR);
        public static readonly ShortcutAction OpenSearch = new("Search", KeyCode.VcLeftMeta, KeyCode.VcS);
        public static readonly ShortcutAction OpenSettings = new("Settings", KeyCode.VcLeftMeta, KeyCode.VcI);
        public static readonly ShortcutAction ProjectScreen = new("Project", KeyCode.VcLeftMeta, KeyCode.VcP);
        public static readonly ShortcutAction QuickLinkMenu = new("Quick Link", KeyCode.VcLeftMeta, KeyCode.VcX);
        public static readonly ShortcutAction EmojiPanel = new("Emojis", KeyCode.VcLeftMeta, KeyCode.VcPeriod);

        // System Navigation
        public static readonly ShortcutAction TogglePreviewPane = new("Preview Pane", KeyCode.VcLeftMeta, KeyCode.VcTab);
        public static readonly ShortcutAction NewVirtualDesktop = new("New Desktop", KeyCode.VcLeftMeta, KeyCode.VcLeftControl, KeyCode.VcD);
        public static readonly ShortcutAction NextDesktop = new("Next Desktop", KeyCode.VcLeftMeta, KeyCode.VcLeftControl, KeyCode.VcRight);
        public static readonly ShortcutAction PreviousDesktop = new("Previous Desktop", KeyCode.VcLeftMeta, KeyCode.VcLeftControl, KeyCode.VcLeft);
        public static readonly ShortcutAction CloseVirtualDesktop = new("Close Desktop", KeyCode.VcLeftMeta, KeyCode.VcLeftControl, KeyCode.VcF4);
        //public static readonly ShortcutAction MaximizeWindow = new("Win+Up", KeyCode.VcLeftMeta, KeyCode.VcUp);
        //public static readonly ShortcutAction MinimizeWindow = new("Win+Down", KeyCode.VcLeftMeta, KeyCode.VcDown);
        //public static readonly ShortcutAction SnapLeft = new("Win+Left", KeyCode.VcLeftMeta, KeyCode.VcLeft);
        //public static readonly ShortcutAction SnapRight = new("Win+Right", KeyCode.VcLeftMeta, KeyCode.VcRight);
        public static readonly ShortcutAction MoveWindowBetweenMonitors = new("Move Window", KeyCode.VcLeftMeta, KeyCode.VcLeftShift, KeyCode.VcLeft);
        //public static readonly ShortcutAction CycleWindows = new("Alt+Esc", KeyCode.VcLeftAlt, KeyCode.VcEscape);
        public static readonly ShortcutAction ScreenshotActiveWindow = new("Alt+PrtScn", KeyCode.VcLeftAlt, KeyCode.VcPrintScreen);

        // File and Folder Management
        public static readonly ShortcutAction NewFolder = new("New Folder", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcN);
        public static readonly ShortcutAction OpenTaskManager = new("Task Manager", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcEscape);
        //public static readonly ShortcutAction DeleteItem = new("Ctrl+D", KeyCode.VcLeftControl, KeyCode.VcD);
        //public static readonly ShortcutAction PermanentDeleteItem = new("Shift+Delete", KeyCode.VcLeftShift, KeyCode.VcDelete);
        //public static readonly ShortcutAction SelectAddressBar = new("Alt+D", KeyCode.VcLeftAlt, KeyCode.VcD);

        // Accessibility Shortcuts
        public static readonly ShortcutAction MagnifierZoomIn = new("Zoom In", KeyCode.VcLeftMeta, KeyCode.VcEquals);
        public static readonly ShortcutAction MagnifierZoomOut = new("Zoom Out", KeyCode.VcLeftMeta, KeyCode.VcMinus);
        public static readonly ShortcutAction ExitMagnifier = new("Close Magnifier", KeyCode.VcLeftMeta, KeyCode.VcEscape);
        public static readonly ShortcutAction OpenContextMenu = new("Context Menu", KeyCode.VcLeftShift, KeyCode.VcF10);
        public static readonly ShortcutAction FocusTaskbar = new("Focus Taskbar", KeyCode.VcLeftMeta, KeyCode.VcT);

        // Command Prompt Shortcuts
        public static readonly ShortcutAction CMD_SelectAllText = new("CMD Select All", KeyCode.VcLeftControl, KeyCode.VcA);
        public static readonly ShortcutAction CMD_CopyText = new("CMD Copy", KeyCode.VcLeftControl, KeyCode.VcC);
        public static readonly ShortcutAction CMD_PasteText = new("CMD Paste", KeyCode.VcLeftControl, KeyCode.VcV);
        public static readonly ShortcutAction CMD_EnterMarkMode = new("CMD Mark", KeyCode.VcLeftControl, KeyCode.VcM);
        public static readonly ShortcutAction CMD_FindText = new("CMD Find", KeyCode.VcLeftControl, KeyCode.VcF);
        public static readonly ShortcutAction CMD_CommandHistory = new("CMD History", KeyCode.VcF7);
        public static readonly ShortcutAction CMD_RunAsAdmin = new("CMD Run as Admin", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcEnter);

        // Browser Shortcuts
        public static readonly ShortcutAction NewTab = new("Ctrl+T", KeyCode.VcLeftControl, KeyCode.VcT);
        public static readonly ShortcutAction ReopenClosedTab = new("Ctrl+Shift+T", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcT);
        public static readonly ShortcutAction CloseTab = new("Ctrl+W", KeyCode.VcLeftControl, KeyCode.VcW);
        public static readonly ShortcutAction SwitchTabs = new("Ctrl+Tab", KeyCode.VcLeftControl, KeyCode.VcTab);
        public static readonly ShortcutAction SwitchToPreviousTab = new("Ctrl+Shift+Tab", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcTab);
        public static readonly ShortcutAction Browser_SelectAddressBar = new("Ctrl+L", KeyCode.VcLeftControl, KeyCode.VcL);
        public static readonly ShortcutAction BookmarkPage = new("Ctrl+D", KeyCode.VcLeftControl, KeyCode.VcD);
        public static readonly ShortcutAction ReloadPage = new("Ctrl+R", KeyCode.VcLeftControl, KeyCode.VcR);
        public static readonly ShortcutAction FindOnPage = new("Ctrl+F", KeyCode.VcLeftControl, KeyCode.VcF);
        public static readonly ShortcutAction IncognitoWindow = new("Ctrl+Shift+N", KeyCode.VcLeftControl, KeyCode.VcLeftShift, KeyCode.VcN);
    }
}
