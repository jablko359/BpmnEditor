using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Models.Elements
{
    public abstract class IdElement : IBaseElement
    {
        public Guid Guid { get; }

        protected IdElement()
        {
            Guid = Guid.NewGuid();
        }

        public string GetId()
        {
            return Guid.ToString();
        }
    }
}
