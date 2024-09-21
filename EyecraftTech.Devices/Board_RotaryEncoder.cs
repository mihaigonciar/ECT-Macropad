﻿using EyecraftTech.Commons;

namespace EyecraftTech.Devices
{
    public class Board_RotaryEncoder
    {
        private byte _rawPosition = 0;

        public readonly Board_B15E2J1_1 Board;

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

        public ByteEvent RawPositionChanged;

        public IntEvent Rotated;
        public VoidEvent PulseUp;
        public VoidEvent PulseDown;

        internal Board_RotaryEncoder(Board_B15E2J1_1 parentBoard, string id) 
        {
            Board = parentBoard;

            ID = id;
            Button = new(parentBoard, id, false);

            Rotated += OnRotated;
        }

        public void OnClick(IAction action) => Button.OnClick(action);
        public void OnPulseUp(IAction action) => PulseUp = action.Execute;
        public void OnPulseDown(IAction action) => PulseDown = action.Execute;

        private void OnRotated(int val)
        {
            if (val > 0) 
            {
                PulseUp?.Invoke();
                return;
            }

            if (val < 0)
            {
                PulseDown?.Invoke();
                return;
            }
        }
    }
}
