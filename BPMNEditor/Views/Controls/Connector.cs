using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Views.Controls
{
    public class Connector : Control
    {
        private DocumentView _documentView;
        private bool _isDragging;

       

        public Connector()
        {
            Loaded += Connector_Loaded;
            MouseLeftButtonDown += Connector_MouseLeftButtonDown;
            MouseLeftButtonUp += Connector_MouseLeftButtonUp;
            MouseMove += Connector_MouseMove;
            LayoutUpdated += Connector_LayoutUpdated;
            //  UpdatePosition();
        }

        private void Connector_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDragging)
            {
                var documentDataContext = _documentView.DataContext as DocumentViewModel;
                documentDataContext?.DrawConnectorLine(e.GetPosition(_documentView));
            }
        }

        private void Connector_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                var documentDataContext = _documentView.DataContext as DocumentViewModel;
                documentDataContext?.EndDrawConnectionLine(e.GetPosition(_documentView));
                _isDragging = false;
            }
            this.ReleaseMouseCapture();
        }

        private void Connector_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var viewModel = this.DataContext as ConnectorViewModel;
            if (viewModel != null)
            {
                viewModel.ConnectorStart();
                _isDragging = true;
                this.CaptureMouse();
            }

            e.Handled = true;
        }

        private void Connector_Loaded(object sender, RoutedEventArgs e)
        {
            _documentView = VisualHelper.FindParent<DocumentView>(this);
        }

        private void Connector_LayoutUpdated(object sender, EventArgs e)
        {
            ConnectorViewModel viewModel = DataContext as ConnectorViewModel;
            if (viewModel != null)
            {
                viewModel.UpdatePosition();
            }
            
        }
    }
}
