using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [DisplayName("Gateway")]
    [Draggable(typeof(IDocumentElement))]
    [ElementViewModel(typeof(GatewayViewModel), GatewayViewModel.InitialWidth, GatewayViewModel.InitialHeight)]
    public class GatewayElement : VisualElement
    {
        
    }

    public enum GatewayType
    {
        None, Or, Xor, EventBased, Parallel
    }
    
}
