using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Actions
{
    public class PropertyMemento
    {
        public object Value { get; }    
        public string Name { get; }

        public PropertyMemento(object value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
