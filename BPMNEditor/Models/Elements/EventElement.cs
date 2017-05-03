using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Serialization.XpdlActivities;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [DisplayName("Event")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(EventActivityFactory))]
    [ElementViewModel(typeof(EventViewModel),EventViewModel.InitialWidth, EventViewModel.InitialWidth)]
    public class EventElement : VisualElement
    {
        public EventType Type { get; set; }
    }

    public enum EventType
    {
        Start, Intermediate, End
    }
}
