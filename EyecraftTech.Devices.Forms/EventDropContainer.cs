namespace EyecraftTech.Devices.Forms
{
    public enum EventType
    {
        Click,
        Press,
        Release,
        Increase,
        Decrease
    }

    public partial class EventDropContainer : UserControl
    {
        public EventDropContainer()
        {
            InitializeComponent();
        }

        public Board_Button Target;
        public EventType EventType { get; set; }

        public void Attach(Board_Button eventTrigger)
        {
            Target = eventTrigger;
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            var x = e.Data.GetFormats();

            e.Effect = DragDropEffects.Copy;
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(e.Data.GetFormats()[0]) is not IAction action) return;

            SetAction(action);
        }

        private void SetAction(IAction action)
        {
            if (action == null) 
            {
                label1.Text = "_";
            }
            else
            {
                label1.Text = action.Description;

            }

            switch (EventType)
            {
                case EventType.Click:
                    Target.OnClick(action);
                    return;
                case EventType.Press:
                    Target.OnPress(action);
                    return;
                case EventType.Release:
                    Target.OnRelease(action);
                    return;

            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                SetAction(null);
            }
        }
    }
}
