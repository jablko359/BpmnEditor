using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [Draggable(typeof(IDocumentElement))]
    [ElementViewModel(typeof(EventViewModel),EventViewModel.InitialWidth, EventViewModel.InitialWidth)]
    public class Event : IdElement
    {

    }

    public enum EventType
    {
        Start, Intermediate, End
    }
}
