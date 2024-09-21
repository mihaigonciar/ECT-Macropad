namespace EyecraftTech.Devices.Forms
{
    public partial class ActionCard : UserControl
    {
        public readonly IAction Action;

        public ActionCard(IAction action)
        {
            InitializeComponent();

            Action = action;
            label1.Text = action.Description;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this.Action, DragDropEffects.Copy);
        }
    }
}
