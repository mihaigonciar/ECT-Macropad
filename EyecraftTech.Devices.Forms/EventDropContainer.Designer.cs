namespace EyecraftTech.Devices.Forms
{
    partial class EventDropContainer
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 150);
            label1.TabIndex = 0;
            label1.Text = "_";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.DragDrop += label1_DragDrop;
            label1.DragEnter += label1_DragEnter;
            label1.MouseClick += label1_MouseClick;
            // 
            // EventDropContainer
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(label1);
            Name = "EventDropContainer";
            DragDrop += label1_DragDrop;
            DragEnter += label1_DragEnter;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}
