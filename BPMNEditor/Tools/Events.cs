using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools
{
    public class LocationChagnedEventArgs : EventArgs
    {
        public double VerticalChange { get; private set; }
        public double HorizontalChange { get; private set; }

        public LocationChagnedEventArgs(double verticalChange, double horizontalChange)
        {
            VerticalChange = verticalChange;
            HorizontalChange = horizontalChange;
        }
    }

    public class SelectionChangedEventArgs : EventArgs
    {
        public BaseElementViewModel SelectedItem { get; private set; }

        public SelectionChangedEventArgs(BaseElementViewModel selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
