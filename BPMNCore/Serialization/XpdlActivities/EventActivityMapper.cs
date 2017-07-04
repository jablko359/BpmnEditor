using System;
using BPMNCore.Elements;
using XPDL.Xpdl;

namespace BPMNCore.Serialization.XpdlActivities
{
    public class EventActivityMapper : BaseActivityMapper
    {
        public override void ProcessActivity(Activity activity, IBaseElement baseElement)
        {
            EventElement eventElement = GetType<EventElement>(baseElement);
            Event @event = new Event();
            Type xpdlType = XpdlTypeAttribute.GetCorrespondingType(eventElement.Type);
            if (xpdlType != null)
            {
                @event.Item = Activator.CreateInstance(xpdlType);
            }
            activity.Item = @event;
        }

        protected override IBaseElement CreateElement(object xpdlItem)
        {
            Event @event = GetXpdlType<Event>(xpdlItem);
            EventElement eventElement = new EventElement();
            EventType type = XpdlTypeAttribute.GetCorrespondingEnum<EventType>(@event.Item.GetType());
            eventElement.Type = type;
            return eventElement;
        }
    }
}
