using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [ElementViewModel(typeof(GatewayViewModel), GatewayViewModel.InitialWidth, GatewayViewModel.InitialHeight)]
    public class Gateway : IBaseElement
    {
    }
}
