using BPMNCore.Serialization.XpdlActivities;
using XPDL.Xpdl;

namespace BPMNCore.Elements
{
    public enum EventType
    {
        [XpdlType(typeof(StartEvent))]
        Start,
        [XpdlType(typeof(IntermediateEvent))]
        Intermediate,
        [XpdlType(typeof(EndEvent))]
        End
    }
}