using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views.Controls
{
    public class Connector : Control
    {
        public Connector()
        {
            Loaded += Connector_Loaded;
            this.MouseLeftButtonDown += Connector_MouseLeftButtonDown;
            this.LayoutUpdated += Connector_LayoutUpdated;
        }

        private void Connector_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((ConnectorViewModel)DataContext).ConnectorStart();
        }

        private void Connector_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var parentUserControl = VisualHelper.FindParent<DragableUserControl>(this);
            BaseElementViewModel viewModel = parentUserControl.DataContext as BaseElementViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Incorrect Data Context. Failed to create Connector");
            }
            DataContext = new ConnectorViewModel(viewModel);
        }

        private void Connector_LayoutUpdated(object sender, EventArgs e)
        {
            Console.WriteLine();
        }
    }
}
