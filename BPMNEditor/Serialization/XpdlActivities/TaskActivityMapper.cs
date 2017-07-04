using System;
using BPMNCore;
using BPMNEditor.Models.Elements;
using XPDL.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public class TaskActivityMapper : BaseActivityMapper
    {
        public override void ProcessActivity(Activity activity, IBaseElement baseElement)
        {
            TaskElement taskElement = GetType<TaskElement>(baseElement);
            activity.Name = taskElement.Name;
            Implementation implementation = new Implementation();
            Task task = new Task();
            implementation.Item = task;
            activity.Item = implementation;
        }

        protected override IBaseElement CreateElement(object xpdlItem)
        {
            Implementation task = GetXpdlType<Implementation>(xpdlItem);
            return new TaskElement();
        }
    }
}