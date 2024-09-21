using SharpHook.Native;
using System.Runtime.Serialization;

namespace EyecraftTech.Devices
{
    public class ShortcutAction : IAction
    {
        private readonly string _desc;
        private readonly KeyCode[] _keys;
        private readonly ShortcutUseMode _mode;

        public string Description => _desc;

        public ShortcutAction(string description, ShortcutUseMode mode, params KeyCode[] keys)
        {
            TEST_Shortcuts.Actions.Add(this);

            _desc = description;
            _keys = keys;
            _mode = mode;
        }

        public ShortcutAction(string description, params KeyCode[] keys) : this(description, ShortcutUseMode.Pulse, keys) { }

        public void Execute()
        {
            switch (_mode)
            {
                case ShortcutUseMode.Press:
                    InputSimulator.KeyStrokes(false, _keys);
                    return;
                case ShortcutUseMode.Release:
                    InputSimulator.KeyStrokes(true, _keys);
                    return;
                case ShortcutUseMode.Pulse:
                default:
                    InputSimulator.Combo(_keys);
                    return;
            }
        }
    }
}
