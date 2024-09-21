using EyecraftTech.Commons;
using EyecraftTech.PicoHandler;
using SharpHook;
using SharpHook.Native;
using System.Drawing;

namespace EyecraftTech.Devices
{
    public class Board_B15E2J1_1
    {
        public static Board_B15E2J1_1 Instance = null;

        private bool _isBoardConnected = false;

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

        public bool IsBoardConnected
        {
            get => _isBoardConnected; private set
            {
                _isBoardConnected = value;
                OnBoardChangedConnectionState();
            }
        }

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

            F1.Down += OnF1Down;
            F1.Up += OnF1Up;

            E1.Rotated += OnE1Rotated;

            Pico.Board.HardwareConnected += OnHardwareConnected;
            Pico.Board.HardwareDisconnected += OnHardwareDisconnected;

            if (Pico.Board.IsBoardConnected)
            {
                OnHardwareConnected();
            }
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

        private void OnHardwareDisconnected()
        {
            IsBoardConnected = false;
        }

        private void OnBoardChangedConnectionState()
        {
            foreach (Board_Button btn in _buttonMatrix)
            {
                if (btn == null) continue;

                btn.SetEnabledState(IsBoardConnected);
            }

            E1.SetEnabledState(IsBoardConnected);
            E2.SetEnabledState(IsBoardConnected);
        }

        private void OnF1Down() => SimulateKeyStrokes(true, KeyCode.VcLeftAlt, KeyCode.VcTab);
        private void OnF1Up() => SimulateKeyStrokes(false, KeyCode.VcLeftAlt, KeyCode.VcTab);

        private void SimulateKeyStrokes(bool press, params KeyCode[] keys)
        {
            foreach(var item in keys)
            {
                if (press == true)
                {
                    _testSimulator.SimulateKeyPress(item);
                }
                else
                {
                    _testSimulator.SimulateKeyRelease(item);
                }
            }
        }

        private void OnE1Rotated(int val)
        {
            if (val > 0)
            {
                _testSimulator.SimulateKeyPress(KeyCode.VcVolumeUp);
            }
            else
            {
                _testSimulator.SimulateKeyPress(KeyCode.VcVolumeDown);
            }
        }

        readonly EventSimulator _testSimulator = new();

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

    public interface IBoardElement
    {
        bool ActionsEnabled { get; }
        void SetEnabledState(bool state);
    }

    public class Board_Button : IBoardElement
    {
        private bool _actionsEnabled = false;
        private bool _state = false;

        public readonly string ID;
        private readonly int _idNumber;

        /// <summary>
        /// TRUE > Button pressed. False otherwise.
        /// </summary>
        public bool State
        {
            get => _state; 
            set
            {
                if (_state == value) return; 
                // avoid triggering the same state multiple times

                _state = value;

                if (value == false)
                {
                    Click?.Invoke();
                    Up?.Invoke();
                }
                else
                {
                    Down?.Invoke();
                }

                StateChanged?.Invoke(value);

                //Console.WriteLine($"{ID} Has state: {value}");
            }
        }

        public VoidEvent Click;
        public VoidEvent Up;
        public VoidEvent Down;
        public BoolEvent StateChanged;

        public ColorEvent ColorChanged;

        public readonly bool HasLED;
        public Color LEDColor { get; private set; } = Color.Purple;
        public float LEDBrightness { get; private set; } = 1f;

        public bool ActionsEnabled { get => _actionsEnabled; }

        public readonly Board_B15E2J1_1 Board;

        internal Board_Button(Board_B15E2J1_1 parentBoard, string iD, bool hasLED = true)
        {
            Board = parentBoard;

            ID = iD;
            _idNumber = int.Parse(iD[1..]);
            HasLED = hasLED;

            if (HasLED == false)
            {
                LEDColor = Color.White;
            }
        }

        public void ChangeColor(Pico board, Color newColor, float brightness)
        {
            if (Board.IsBoardConnected == false) return;

            if (_actionsEnabled == false) return;

            LEDColor = newColor;
            LEDBrightness = brightness;

            board.SendData($"F-{_idNumber}-{newColor.R}-{newColor.G}-{newColor.B}-{Math.Clamp(brightness, 0f, 1f)}", out _);
            
            ColorChanged?.Invoke(newColor, brightness);
        }

        public void SetEnabledState(bool state)
        {
            _actionsEnabled = state;
        }
    }

    public class Board_RotaryEncoder : IBoardElement
    {
        private bool _actionsEnabled = false;
        private byte _rawPosition = 0;

        public readonly string ID;
        public readonly Board_Button Button;

        public byte RawPosition
        {
            get => _rawPosition;
            set
            {
                if (value == _rawPosition) return;

                RawPositionChanged?.Invoke(value);

                if (value == 0 && _rawPosition == 255) // increment
                {
                    Rotated?.Invoke(1); // greater value means positive pulse
                }
                else if (value == 255 && _rawPosition == 0) // decrement
                {
                    Rotated?.Invoke(-1); // greater value means positive pulse
                }
                else
                {
                    Rotated?.Invoke(Math.Sign(value - _rawPosition)); // greater value means positive pulse
                }

                _rawPosition = value;
            }
        }

        public ByteEvent RawPositionChanged { get; set; }

        /// <summary>
        /// In most cases we want to use this event, because the encoder 
        /// can rotate endlessly in a direction while its values will circle 0-255.
        /// </summary>
        public IntEvent Rotated { get; set; }

        public bool ActionsEnabled { get => _actionsEnabled; }

        public readonly Board_B15E2J1_1 Board;

        internal Board_RotaryEncoder(Board_B15E2J1_1 parentBoard, string id) 
        {
            Board = parentBoard;

            ID = id;
            Button = new(parentBoard, id, false);
        }

        public void SetEnabledState(bool state)
        {
            _actionsEnabled = state;
            Button.SetEnabledState(state);
        }
    }
}
