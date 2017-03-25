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
    [ElementViewModel(typeof(PoolViewModel), PoolViewModel.InitialWidth, PoolViewModel.InitialHeight)]
    class Pool : IBaseElement
    {
    }
}
