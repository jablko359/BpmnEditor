using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Xpdl;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public class EventActivityFactory : BaseActivityFactory
    {
        public override void ProcessActivity(Activity activity, IBaseElement baseElement)
        {
            EventElement eventElement = GetType<EventElement>(baseElement);
            Event @event = new Event();
            switch (eventElement.Type)
            {
                case EventType.Start:
                    @event.Item = new StartEvent();
                    break;
                case EventType.End:
                    @event.Item = new EndEvent();
                    break;
                case EventType.Intermediate:
                    @event.Item = new IntermediateEvent();
                    break;
            }
            activity.Item = @event;
        }
    }
}
