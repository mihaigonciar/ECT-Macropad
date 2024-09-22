using System.Windows.Forms;

namespace EyecraftTech.Devices.Forms
{
    public partial class Board_ButtonEditor : UserControl
    {
        public Color ButtonUpColor = Color.LightSkyBlue;
        public Color ButtonDownColor = Color.Cyan;

        private Board_Button _target;

        public Board_ButtonEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BackColor = Color.FromArgb(44, 44, 44);
            ButtonID.ForeColor = Color.White;
        }

        public void Attach(Board_Button button)
        {
            ButtonID.Text = button.ID;
            button.StateChanged += OnButtonStateChanged;

            _target = button;
            _target.ColorChanged += OnLEDColorChanged;

            SetControlColors(_target.LEDColor);

            if (button.HasLED)
            {
                LEDIndicatorPanel.Visible = true;
                LEDIndicatorPanel.BackColor = ButtonUpColor;
                ButtonID.ForeColor = Color.White;
            }
            else
            {
                LEDIndicatorPanel.Visible = false;
                BackColor = ButtonUpColor;
                ButtonID.ForeColor = Color.Black;
            }
        }

        private void SetControlColors(Color color)
        {
            ButtonDownColor = color;
            ButtonUpColor = ControlPaint.Dark(color, 0.1f);
        }

        private void OnLEDColorChanged(Color color, float brightness) => SetControlColors(color);
        private void OnButtonStateChanged(bool state)
        {
            if (_target.HasLED)
            {
                LEDIndicatorPanel.BackColor = state == true ? ButtonDownColor : ButtonUpColor;
            }
            else
            {
                BackColor = state == true ? ButtonDownColor : ButtonUpColor;
            }
        }

        private void LEDIndicatorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (_target.Board.IsBoardConnected == false) return;

            ColorDialog colorPicker = new() { FullOpen = true, };

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                _target.ChangeColor(PicoHandler.Pico.Board, colorPicker.Color, _target.LEDBrightness);
                SetControlColors(_target.LEDColor);
            }
        }
    }
}
