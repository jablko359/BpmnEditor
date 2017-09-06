using BPMNCore;
using XPDL.Xpdl;

namespace BPMNElements
{
    public class ExampleActivityMapper : BaseActivityMapper
    {
        public override void ProcessActivity(Activity activity, IBaseElement baseElement)
        {
            ExampleElement taskElement = GetType<ExampleElement>(baseElement);
            activity.Name = taskElement.Name;
            Implementation implementation = new Implementation();
            XPDL.Xpdl.BlockActivity task = new XPDL.Xpdl.BlockActivity();

            activity.Item = implementation;
        }

        protected override IBaseElement CreateElement(object xpdlItem)
        {
            Implementation task = GetXpdlType<Implementation>(xpdlItem);
            return new ExampleElement();
        }
    }
}