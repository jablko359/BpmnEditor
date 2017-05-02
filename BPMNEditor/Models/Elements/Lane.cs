using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [Draggable(typeof(IPoolElement))]
    [ElementViewModel(typeof(LaneViewModel), EventViewModel.InitialWidth, EventViewModel.InitialWidth)]
    public class Lane : IdElement
    {
    }
}
