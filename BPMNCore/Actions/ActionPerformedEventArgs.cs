using System;

namespace BPMNCore.Actions
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
