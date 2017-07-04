using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [DisplayName("Lane")]
    [Draggable(typeof(IPoolElement))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(LaneViewModel), EventViewModel.InitialWidth, EventViewModel.InitialWidth)]
    public class LaneElement : VisualElement
    {
        public LaneElement()
        {
            Name = "Lane";
        }
    }
}
