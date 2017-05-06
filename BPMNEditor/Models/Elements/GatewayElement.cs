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
    [DisplayName("Gateway")]
    [Draggable(typeof(IDocumentElement))]
    [XpdlActivityFactory(typeof(GatewayActivityFactory))]
    [ToolboxVisibile]
    [ElementViewModel(typeof(GatewayViewModel), GatewayViewModel.InitialWidth, GatewayViewModel.InitialHeight)]
    public class GatewayElement : VisualElement
    {
        public GatewayType Type { get; set; }
    }

    public enum GatewayType
    {
        None, Or, Xor, EventBased, Parallel
    }
    
}
