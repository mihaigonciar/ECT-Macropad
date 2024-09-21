namespace EyecraftTech.Devices.Forms
{
    public partial class ECT_RotaryEncoder : ECT_Button
    {
        public ECT_RotaryEncoder()
        {
            InitializeComponent();
        }

        public void Attach(Board_RotaryEncoder encoder)
        {
            Attach(encoder.Button);

            ButtonID.Text = encoder.ID;
            encoder.RawPositionChanged += OnRawPositionChanged;
            EncoderPositionLabel.Text = encoder.RawPosition.ToString();
        }

        private void OnRawPositionChanged(byte data)
        {
            if (this.InvokeRequired)
            {
                EncoderPositionLabel.Invoke(
                    delegate 
                    { 
                        OnRawPositionChanged(data); 
                    }
                );
            }
            else
            {
                EncoderPositionLabel.Text = data.ToString();
            }
        }
    }
}
