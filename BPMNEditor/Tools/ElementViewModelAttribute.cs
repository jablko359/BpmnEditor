using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Tools
{
    

    public class ElementViewModelAttribute : Attribute
    {
        public Type ViewModelType { get; }

        public ElementViewModelAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
    }
}
