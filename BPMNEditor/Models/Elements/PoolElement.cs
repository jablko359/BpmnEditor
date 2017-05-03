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
    public class PoolElement : VisualElement
    {
        public string Name { get; set; }

        public Guid ProcessGuid { get; set; }

        public List<LaneElement> Lanes { get; set; }

        public PoolElement()
        {
            Lanes = new List<LaneElement>();
            ProcessGuid = Guid.NewGuid();
        }

        public PoolElement(Guid processGuid)
        {
            Lanes = new List<LaneElement>();
            ProcessGuid = processGuid;
        }

    }
}
