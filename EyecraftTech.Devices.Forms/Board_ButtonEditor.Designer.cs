namespace EyecraftTech.Devices.Forms
{
    partial class Board_ButtonEditor
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
            ButtonID = new Label();
            LEDIndicatorPanel = new Panel();
            SuspendLayout();
            // 
            // ButtonID
            // 
            ButtonID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonID.Font = new Font("Segoe UI", 16F);
            ButtonID.Location = new Point(0, 0);
            ButtonID.Name = "ButtonID";
            ButtonID.Size = new Size(80, 80);
            ButtonID.TabIndex = 0;
            ButtonID.Text = "_ID";
            ButtonID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LEDIndicatorPanel
            // 
            LEDIndicatorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LEDIndicatorPanel.BackColor = Color.White;
            LEDIndicatorPanel.ForeColor = SystemColors.ControlText;
            LEDIndicatorPanel.Location = new Point(0, 0);
            LEDIndicatorPanel.Margin = new Padding(0);
            LEDIndicatorPanel.Name = "LEDIndicatorPanel";
            LEDIndicatorPanel.Size = new Size(80, 20);
            LEDIndicatorPanel.TabIndex = 1;
            LEDIndicatorPanel.MouseClick += LEDIndicatorPanel_MouseClick;
            // 
            // ECT_Button
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            Controls.Add(LEDIndicatorPanel);
            Controls.Add(ButtonID);
            Name = "ECT_Button";
            Size = new Size(80, 80);
            ResumeLayout(false);
        }

        #endregion

        protected Label ButtonID;
        private Panel LEDIndicatorPanel;
    }
}
