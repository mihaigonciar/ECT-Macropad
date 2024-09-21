using SharpHook;
using SharpHook.Native;

namespace EyecraftTech.Devices
{
    public static class InputSimulator
    {
        private static readonly EventSimulator _simulator = new();

        internal static void KeyStrokes(bool press, params KeyCode[] keys)
        {
            foreach (var item in keys)
            {
                if (press == true)
                {
                    _simulator.SimulateKeyPress(item);
                }
                else
                {
                    _simulator.SimulateKeyRelease(item);
                }
            }
        }

        internal static void Combo(params KeyCode[] keys)
        {
            foreach (var item in keys)
            {
                _simulator.SimulateKeyPress(item);
            }

            foreach (var item in keys)
            {
                _simulator.SimulateKeyRelease(item);
            }
        }
    }
}
