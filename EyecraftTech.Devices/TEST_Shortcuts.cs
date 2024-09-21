using SharpHook.Native;

namespace EyecraftTech.Devices
{
    public static class TEST_Shortcuts
    {
        public static readonly List<IAction> Actions = [];

        // Sound
        public static readonly ShortcutAction Volume_Mute = new("Volume Mute", KeyCode.VcVolumeMute);
        public static readonly ShortcutAction Volume_Up = new("Volume Increase", KeyCode.VcVolumeUp);
        public static readonly ShortcutAction Volume_Down = new("Volume Decrease", KeyCode.VcVolumeDown);

        // Windows control
        public static readonly ShortcutAction TogglePreviewPane = new("Win+Tab", KeyCode.VcLeftMeta, KeyCode.VcTab);
    }
}
