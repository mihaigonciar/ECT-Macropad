using SharpHook.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyecraftTech.Devices.Forms
{
    public class Board_ButtonEventDropContainerNEW : Board_EventDropContainerBase<Board_Button>
    {
        private readonly ButtonEventType _buttonEventType;

        public Board_ButtonEventDropContainerNEW(Board_Button target, ButtonEventType eventType) : base(target)
        {
            _buttonEventType = eventType;
        }

        protected override void SetAction(IAction action)
        {
            base.SetAction(action);

            switch (_buttonEventType)
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
    }
}
