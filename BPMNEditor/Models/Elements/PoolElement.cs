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
    [DisplayName("Pool")]
    [Draggable(typeof(IDocumentElement))]
    [ElementViewModel(typeof(PoolViewModel), PoolViewModel.InitialWidth, PoolViewModel.InitialHeight)]
    public class PoolElement : IdElement
    {
        public Guid ProcessGuid { get; set; }

        public PoolElement()
        {
            ProcessGuid = Guid.NewGuid();
        }

        public PoolElement(Guid processGuid)
        {
            ProcessGuid = processGuid;
        }

    }
}
