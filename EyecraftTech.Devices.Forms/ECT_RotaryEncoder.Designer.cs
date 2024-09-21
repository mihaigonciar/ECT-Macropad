namespace EyecraftTech.Devices.Forms
{
    partial class ECT_RotaryEncoder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EncoderPositionLabel = new Label();
            SuspendLayout();
            // 
            // EncoderPositionLabel
            // 
            EncoderPositionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EncoderPositionLabel.AutoSize = true;
            EncoderPositionLabel.Location = new Point(52, 0);
            EncoderPositionLabel.Name = "EncoderPositionLabel";
            EncoderPositionLabel.Size = new Size(28, 15);
            EncoderPositionLabel.TabIndex = 1;
            EncoderPositionLabel.Text = "###";
            EncoderPositionLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // ECT_RotaryEncoder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EncoderPositionLabel);
            Name = "ECT_RotaryEncoder";
            Controls.SetChildIndex(EncoderPositionLabel, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EncoderPositionLabel;
    }
}
