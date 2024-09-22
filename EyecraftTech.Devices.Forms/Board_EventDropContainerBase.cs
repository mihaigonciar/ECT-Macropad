namespace EyecraftTech.Devices.Forms
{
    public abstract class Board_EventDropContainerBase<T> : Panel
    {
        private readonly Label _label;

        private T _target;
        public T Target => _target;

        public Board_EventDropContainerBase(T target)
        {
            SuspendLayout();

            _label = new Label() 
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Text = "_",
                TextAlign = ContentAlignment.MiddleCenter,
                AllowDrop = true,
            };

            _label.MouseClick += OnMouseClick;
            _label.DragEnter += OnDragEnter;
            _label.DragDrop += OnDragDrop;

            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(_label);

            ResumeLayout(false);

            Attach(target);
        }

        public void Attach(T target) => _target = target;

        private void OnMouseClick(object? sender, MouseEventArgs e)
        {
            // Unbind an action from the container
            if (e.Button == MouseButtons.Right)
            {
                SetAction(null);
            }
        }

        private void OnDragEnter(object? sender, DragEventArgs e)
        {
            // Deny data that doesn't inherit from IAction
            if (e.Data.GetData(e.Data.GetFormats()[0]) is not IAction) return;

            e.Effect = DragDropEffects.All;
        }

        private void OnDragDrop(object? sender, DragEventArgs e)
        {
            // Ensure that the data dropped is of type IAction
            if (e.Data.GetData(e.Data.GetFormats()[0]) is not IAction action) return;

            SetAction(action);
        }

        protected virtual void SetAction(IAction action) => _label.Text = action == null ? "_" : action.Description;
    }
}
