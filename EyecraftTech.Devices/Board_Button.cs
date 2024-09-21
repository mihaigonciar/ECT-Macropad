using System.Drawing;

using EyecraftTech.Commons;
using EyecraftTech.PicoHandler;

namespace EyecraftTech.Devices
{
    public class Board_Button
    {
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

        public bool Handled = false;

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

        public void OnClick(IAction action) => Click = action != null ? action.Execute : null;
        public void OnPress(IAction action) => Down = action != null ? action.Execute : null;
        public void OnRelease(IAction action) => Up = action != null ? action.Execute : null;

        public void ChangeColor(Pico board, Color newColor, float brightness)
        {
            if (Board.IsBoardConnected == false) return;

            LEDColor = newColor;
            LEDBrightness = brightness;

            board.SendData($"F-{_idNumber}-{newColor.R}-{newColor.G}-{newColor.B}-{Math.Clamp(brightness, 0f, 1f)}", out _);
            
            ColorChanged?.Invoke(newColor, brightness);
        }
    }
}
