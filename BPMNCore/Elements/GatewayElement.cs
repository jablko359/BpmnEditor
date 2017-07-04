using System.ComponentModel;
using BPMNCore.DragAndDrop;
using BPMNCore.Serialization.XpdlActivities;
using BPMNCore.ViewModels;
using XPDL.Xpdl;

namespace BPMNCore.Elements
{
    [DisplayName("Gateway")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(GatewayActivityMapper))]
    [ActivityMapper(typeof(Route), typeof(GatewayActivityMapper))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(GatewayViewModel), GatewayViewModel.InitialWidth, GatewayViewModel.InitialHeight)]
    public class GatewayElement : VisualElement
    {
        public GatewayType Type { get; set; }
    }
}
