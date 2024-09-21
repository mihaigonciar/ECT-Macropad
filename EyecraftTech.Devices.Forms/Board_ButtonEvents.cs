using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyecraftTech.Devices.Forms
{
    public partial class Board_ButtonEvents: UserControl
    {
        public Board_Button Target;

        public Board_ButtonEvents()
        {
            InitializeComponent();
        }

        public void Attach(Board_Button target)
        {
            Target = target;
            ButtonIDLabel.Text = target.ID;

            DropContainerClick.Attach(target);
            DropContainerPress.Attach(target);
            DropContainerRelease.Attach(target);
        }
    }
}
