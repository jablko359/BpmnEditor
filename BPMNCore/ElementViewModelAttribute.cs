using System;
using System.Windows;

namespace BPMNCore
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
