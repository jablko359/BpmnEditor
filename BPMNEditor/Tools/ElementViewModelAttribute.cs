using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BPMNEditor.Tools
{
    public class ElementViewModelAttribute : Attribute
    {
        public Type ViewModelType { get; }
        public Size InitialSize { get; }

        public ElementViewModelAttribute(Type viewModelType, double initialWidth, double initialHeight)
        {
            ViewModelType = viewModelType;
            InitialSize = new Size(initialWidth, initialHeight);
        }
    }
}
