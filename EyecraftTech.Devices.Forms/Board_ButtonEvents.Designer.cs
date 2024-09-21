namespace EyecraftTech.Devices.Forms
{
    partial class Board_ButtonEvents
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
            tableLayoutPanel1 = new TableLayoutPanel();
            DropContainerRelease = new EventDropContainer();
            DropContainerClick = new EventDropContainer();
            ButtonIDLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            DropContainerPress = new EventDropContainer();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(DropContainerRelease, 1, 3);
            tableLayoutPanel1.Controls.Add(DropContainerClick, 1, 1);
            tableLayoutPanel1.Controls.Add(ButtonIDLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(DropContainerPress, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 26.8292675F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3902435F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3902435F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3902435F));
            tableLayoutPanel1.Size = new Size(136, 68);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // DropContainerRelease
            // 
            DropContainerRelease.AllowDrop = true;
            DropContainerRelease.BackColor = Color.FromArgb(26, 26, 26);
            DropContainerRelease.Dock = DockStyle.Fill;
            DropContainerRelease.EventType = EventType.Release;
            DropContainerRelease.Location = new Point(57, 53);
            DropContainerRelease.Name = "DropContainerRelease";
            DropContainerRelease.Size = new Size(76, 12);
            DropContainerRelease.TabIndex = 6;
            // 
            // DropContainerClick
            // 
            DropContainerClick.AllowDrop = true;
            DropContainerClick.BackColor = Color.FromArgb(26, 26, 26);
            DropContainerClick.Dock = DockStyle.Fill;
            DropContainerClick.EventType = EventType.Click;
            DropContainerClick.Location = new Point(57, 21);
            DropContainerClick.Name = "DropContainerClick";
            DropContainerClick.Size = new Size(76, 10);
            DropContainerClick.TabIndex = 5;
            // 
            // ButtonIDLabel
            // 
            tableLayoutPanel1.SetColumnSpan(ButtonIDLabel, 2);
            ButtonIDLabel.Dock = DockStyle.Fill;
            ButtonIDLabel.Font = new Font("Segoe UI", 12F);
            ButtonIDLabel.ForeColor = Color.White;
            ButtonIDLabel.Location = new Point(0, 0);
            ButtonIDLabel.Margin = new Padding(0);
            ButtonIDLabel.Name = "ButtonIDLabel";
            ButtonIDLabel.Size = new Size(136, 18);
            ButtonIDLabel.TabIndex = 0;
            ButtonIDLabel.Text = "ButtonIDLabel";
            ButtonIDLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 8F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 18);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(54, 16);
            label1.TabIndex = 1;
            label1.Text = "Click";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 8F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 34);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(54, 16);
            label2.TabIndex = 2;
            label2.Text = "Press";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 8F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 50);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(54, 18);
            label3.TabIndex = 3;
            label3.Text = "Release";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DropContainerPress
            // 
            DropContainerPress.AllowDrop = true;
            DropContainerPress.BackColor = Color.FromArgb(26, 26, 26);
            DropContainerPress.Dock = DockStyle.Fill;
            DropContainerPress.EventType = EventType.Press;
            DropContainerPress.Location = new Point(57, 37);
            DropContainerPress.Name = "DropContainerPress";
            DropContainerPress.Size = new Size(76, 10);
            DropContainerPress.TabIndex = 4;
            // 
            // Board_ButtonEvents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            MinimumSize = new Size(136, 68);
            Name = "Board_ButtonEvents";
            Size = new Size(136, 68);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label ButtonIDLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private EventDropContainer DropContainerRelease;
        private EventDropContainer DropContainerClick;
        private EventDropContainer DropContainerPress;
    }
}
