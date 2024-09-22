using EyecraftTech.PicoHandler;

namespace EyecraftTech.Devices
{
    public class Board_B15E2J1_1 : BoardBase
    {
        #region Hardware

        public Board_Button F1 { get; set; }
        public Board_Button F2  { get; set; }
        public Board_Button F3  { get; set; }
        public Board_Button F4  { get; set; }
        public Board_Button F5  { get; set; }
        public Board_Button F6  { get; set; }
        public Board_Button F7  { get; set; }
        public Board_Button F8  { get; set; }
        public Board_Button F9  { get; set; }
        public Board_Button F10 { get; set; }
        public Board_Button F11 { get; set; }
        public Board_Button F12 { get; set; }
        public Board_Button F13 { get; set; }
        public Board_Button F14 { get; set; }
        public Board_Button F15 { get; set; }

        public Board_RotaryEncoder E1 { get; set; }
        public Board_RotaryEncoder E2 { get; set; }

        // also declare a joystick

        #endregion Hardware

        public Board_B15E2J1_1(Pico board) : base(board)
        {
            F1  = new(this, nameof(F1),  0, 0);
            F2  = new(this, nameof(F2),  0, 1);
            F3  = new(this, nameof(F3),  0, 2);
            F4  = new(this, nameof(F4),  0, 3);
            F5  = new(this, nameof(F5),  0, 4);
            F6  = new(this, nameof(F6),  0, 5);
            F7  = new(this, nameof(F7),  0, 6);
            F8  = new(this, nameof(F8),  0, 7);
            F9  = new(this, nameof(F9),  1, 0);
            F10 = new(this, nameof(F10), 1, 1);
            F11 = new(this, nameof(F11), 1, 2);
            F12 = new(this, nameof(F12), 1, 3);
            F13 = new(this, nameof(F13), 1, 4);
            F14 = new(this, nameof(F14), 1, 5);
            F15 = new(this, nameof(F15), 1, 6);

            E1  = new(this, nameof(E1),  2, 0, 3);
            E2  = new(this, nameof(E2),  2, 1, 4);
        }

        protected override void OnHardwareConnected()
        {
            // TODO: Replace this once we get Profile loading running.

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
    }
}
