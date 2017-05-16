using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.ViewModels;
using Xceed.Wpf.AvalonDock.Layout;

namespace BPMNEditor.Views.Controls
{
    public class GraphDocument : LayoutDocument
    {
        public DocumentViewModel DocumentViewModel { get; private set; }
        
        public GraphDocument(DocumentViewModel documentViewModel)
        {
            DocumentView documentView = new DocumentView {DataContext = documentViewModel};
            Content = documentView;
            Title = documentViewModel.Name;
            DocumentViewModel = documentViewModel;


        }
        
    }
}
