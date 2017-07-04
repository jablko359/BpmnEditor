using System;
using BPMNCore.ViewModels;

namespace BPMNEditor.Tools
{
    public class SelectionChangedEventArgs : EventArgs
    {
        public BaseElementViewModel SelectedItem { get; private set; }

        public SelectionChangedEventArgs(BaseElementViewModel selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}