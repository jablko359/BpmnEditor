using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Actions
{
    public class ActionPerformedEventArgs : EventArgs
    {
        public IAction Action { get; }

        public ActionPerformedEventArgs(IAction action)
        {
            Action = action;
        }
    }
}
