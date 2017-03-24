using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public class HookTempConnector : ConnectorBase
    {

        public HookTempConnector(Hook hook, bool isStart)
        {
            Position = hook.HookPoint;
            SetPlacement(isStart, hook.Orientation);
        }

        private void SetPlacement(bool isStart, Orientation hookOrientation)
        {
            switch (hookOrientation)
            {
                case Orientation.Horizontal:
                    Placemement = isStart ? Placemement.Top : Placemement.Bottom;
                    break;
                case Orientation.Vertical:
                    Placemement = isStart ? Placemement.Right : Placemement.Left;
                    break;
            }
        }

        public override Rect GetParentRectWithMargin(double margin)
        {
            var rect = new Rect(Position, new Size(0, 0));
            return rect;
        }
    }
}
