using System.ComponentModel;
using BPMNCore.DragAndDrop;
using BPMNCore.Serialization.XpdlActivities;
using BPMNCore.ViewModels;
using XPDL.Xpdl;

namespace BPMNCore.Elements
{
    [DisplayName("Event")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(EventActivityMapper))]
    [ActivityMapper(typeof(Event), typeof(EventActivityMapper))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(EventViewModel),EventViewModel.InitialWidth, EventViewModel.InitialWidth)]
    public class EventElement : VisualElement
    {
        public EventType Type { get; set; }
    }
}
