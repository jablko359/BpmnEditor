using System.ComponentModel;
using BPMNCore.DragAndDrop;
using BPMNCore.ViewModels;

namespace BPMNCore.Elements
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
