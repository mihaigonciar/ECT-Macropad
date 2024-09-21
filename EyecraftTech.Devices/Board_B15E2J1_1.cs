using EyecraftTech.Commons;
using EyecraftTech.PicoHandler;

namespace EyecraftTech.Devices
{
    public class Board_B15E2J1_1
    {
        #region Hardware

        private readonly Board_Button[,] _buttonMatrix;
        
        public readonly Board_Button F1;
        public readonly Board_Button F2;
        public readonly Board_Button F3;
        public readonly Board_Button F4;
        public readonly Board_Button F5;
        public readonly Board_Button F6;
        public readonly Board_Button F7;
        public readonly Board_Button F8;
        public readonly Board_Button F9;
        public readonly Board_Button F10;
        public readonly Board_Button F11;
        public readonly Board_Button F12;
        public readonly Board_Button F13;
        public readonly Board_Button F14;
        public readonly Board_Button F15;

        public readonly Board_RotaryEncoder E1;
        public readonly Board_RotaryEncoder E2;

        // also declare a joystick

        #endregion Hardware

        #region Properties

        public bool IsBoardConnected { get; private set; } = false;

        #endregion Properties

        public Board_B15E2J1_1()
        {
            F1 = new(this,nameof(F1));
            F2 = new(this,nameof(F2));
            F3 = new(this,nameof(F3));
            F4 = new(this,nameof(F4));
            F5 = new(this,nameof(F5));
            F6 = new(this,nameof(F6));
            F7 = new(this,nameof(F7));
            F8 = new(this,nameof(F8));
            F9 = new(this,nameof(F9));
            F10 = new(this,nameof(F10));
            F11 = new(this,nameof(F11));
            F12 = new(this,nameof(F12));
            F13 = new(this,nameof(F13));
            F14 = new(this,nameof(F14));
            F15 = new(this,nameof(F15));

            E1 = new(this, nameof(E1));
            E2 = new(this, nameof(E2));

            _buttonMatrix = new Board_Button[,]
            { 
                { F1, F2, F3, F4, F5, F6, F7, F8 },
                { F9, F10, F11, F12, F13, F14, F15, null } 
            };


            Pico.Board.HardwareConnected += OnHardwareConnected;
            Pico.Board.HardwareDisconnected += () => { IsBoardConnected = false; };
            Pico.Board.DataReceived += ReadData;

            if (Pico.Board.IsBoardConnected)
            {
                OnHardwareConnected();
            }

            // Below items will need to be replaced with a user profile that gets loaded
            // TESTS
            F1.OnClick(TEST_Shortcuts.TogglePreviewPane);
            E1.OnClick(TEST_Shortcuts.Volume_Mute);
            E1.OnPulseUp(TEST_Shortcuts.Volume_Up);
            E1.OnPulseDown(TEST_Shortcuts.Volume_Down);
        }

        private void OnHardwareConnected()
        {
            IsBoardConnected = true;

            Pico.Board.SendData(
                "F-1-255-0-255-1|" +
                "F-2-255-0-255-1|" +
                "F-3-255-0-255-1|" +
                "F-4-255-0-255-1|" +
                "F-5-255-0-255-1|" +
                "F-6-255-0-255-1|" +
                "F-7-255-0-255-1|" +
                "F-8-255-0-255-1|" +
                "F-9-255-0-255-1|" +
                "F-10-255-0-255-1|" +
                "F-11-255-0-255-1|" +
                "F-12-255-0-255-1|" +
                "F-13-255-0-255-1|" +
                "F-14-255-0-255-1|" +
                "F-15-255-0-255-1|"
                , out _);
        }

        public void ReadData(byte[] data)
        {
            // This is the button matrix
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_buttonMatrix[i, j] == null) continue;

                    _buttonMatrix[i, j].State = Utils.IsBitSet(data[i], j);
                }
            }

            // encoder 1
            E1.Button.State = Utils.IsBitSet(data[2], 0);
            E1.RawPosition = data[3];

            // encoder 2
            E2.Button.State = Utils.IsBitSet(data[2], 1);
            E2.RawPosition = data[4];

            // joystick 1
            // TODO
        }
    }
}
