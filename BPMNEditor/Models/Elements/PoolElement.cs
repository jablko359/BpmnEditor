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
    [ToolboxVisibile]
    [ElementViewModel(typeof(PoolViewModel), PoolViewModel.InitialWidth, PoolViewModel.InitialHeight)]
    public class PoolElement : VisualElement
    {
        public string Name { get; set; }

        public Guid ProcessGuid { get; set; }

        public List<LaneElement> Lanes { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<IBaseElement> Elements { get; set; }

        public List<ConnectionElement> Connections { get; set; } = new List<ConnectionElement>();
        
        public PoolElement()
        {
            Lanes = new List<LaneElement>();
            Elements = new List<IBaseElement>();
            ProcessGuid = Guid.NewGuid();
            CreatedOn = DateTime.Now;
        }

        public PoolElement(Guid processGuid)
        {
            Lanes = new List<LaneElement>();
            Elements = new List<IBaseElement>();
            CreatedOn = DateTime.Now;
            ProcessGuid = processGuid;
        }

    }
}
