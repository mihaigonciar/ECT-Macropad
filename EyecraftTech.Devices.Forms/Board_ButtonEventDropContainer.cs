namespace EyecraftTech.Devices.Forms
{
    public enum ButtonEventType { Click, Press, Release }
    public enum EncoderEventType { Increase, Decrease }

    public partial class Board_ButtonEventDropContainer : UserControl
    {
        public Board_ButtonEventDropContainer()
        {
            InitializeComponent();
        }

        public Board_Button Target;
        public ButtonEventType EventType { get; set; }

        public void Attach(Board_Button eventTrigger)
        {
            Target = eventTrigger;
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            // Deny data that doesn't inherit from IAction
            if (e.Data.GetData(e.Data.GetFormats()[0]) is not IAction) return;

            e.Effect = DragDropEffects.All;
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the data dropped is of type IAction
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
                case ButtonEventType.Click:
                    Target.OnClick(action);
                    return;
                case ButtonEventType.Press:
                    Target.OnPress(action);
                    return;
                case ButtonEventType.Release:
                    Target.OnRelease(action);
                    return;

            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            // Unbind an action from the container
            if (e.Button == MouseButtons.Right) 
            {
                SetAction(null);
            }
        }
    }
}
