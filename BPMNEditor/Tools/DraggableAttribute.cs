using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Tools
{
    public class DraggableAttribute : Attribute
    {
        public Type DataType { get; }

        public DraggableAttribute(Type dataType)
        {
            DataType = dataType;
        }
    }
}
