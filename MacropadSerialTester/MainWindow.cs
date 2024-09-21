using EyecraftTech.Devices;
using EyecraftTech.PicoHandler;

namespace MacropadDeviceController
{
    enum BoardConnectionState { Disconnected, Connected }

    public partial class MainWindow : Form
    {
        private readonly Board_B15E2J1_1 _board = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pico.Board.RawDataReceived += RawDataReceived;
            Pico.Board.DataReceived += _board.ReadData;

            AttachControlsToBoard();
        }

        private void AttachControlsToBoard()
        {
            Control_F1.Attach(_board.F1);
            Control_F2.Attach(_board.F2);
            Control_F3.Attach(_board.F3);
            Control_F4.Attach(_board.F4);
            Control_F5.Attach(_board.F5);
            Control_F6.Attach(_board.F6);
            Control_F7.Attach(_board.F7);
            Control_F8.Attach(_board.F8);
            Control_F9.Attach(_board.F9);
            Control_F10.Attach(_board.F10);
            Control_F11.Attach(_board.F11);
            Control_F12.Attach(_board.F12);
            Control_F13.Attach(_board.F13);
            Control_F14.Attach(_board.F14);
            Control_F15.Attach(_board.F15);

            Control_E1.Attach(_board.E1);
            Control_E2.Attach(_board.E2);
        }

        private void RawDataReceived(string str)
        {
            try
            {
                this.BeginInvoke(() => { textBox1.Text = str; });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Button3_Click(object sender, EventArgs e) => SendMessage();

        private void SendMessage()
        {
            if (_board.IsBoardConnected == false)
            {
                textBox1.Text = "The device is not connected!";
                return;
            }

            if (Pico.Board.SendData(textBox1.Text, out string msg))
            {
                textBox1.Text = "";
            }
            else
            {
                Console.WriteLine(msg);
                textBox1.Text = msg;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Pico.Board.Disconnect(out _);
            base.OnFormClosing(e);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendMessage();
                e.Handled = true;
            }
        }
    }
}
