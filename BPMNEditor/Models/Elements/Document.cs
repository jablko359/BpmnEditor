using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    public class Document
    {
        public List<IBaseElement> BaseElements
        {
            get; set;
        }

        public List<Pool> Pools { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; private set; }

        public Pool MainPool { get; set; }

        public Guid MainProcessGuid { get; set; }

        public Guid Guid { get; set; }

        public Document()
        {
            BaseElements = new List<IBaseElement>();
            Pools = new List<Pool>();
            CreatedOn = DateTime.Now;
            Guid = Guid.NewGuid();
            MainPool = new Pool();
        }

    }
}
