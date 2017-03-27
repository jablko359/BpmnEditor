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
        private ConnectorViewModel _viewModel;
        private DocumentView _documentView;
        private bool _isDragging;

        public Connector()
        {
            Loaded += Connector_Loaded;
            MouseLeftButtonDown += Connector_MouseLeftButtonDown;
            MouseLeftButtonUp += Connector_MouseLeftButtonUp;
            MouseMove += Connector_MouseMove;
            LayoutUpdated += Connector_LayoutUpdated;
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
            _viewModel.ConnectorStart();
            _isDragging = true;
            this.CaptureMouse();
            e.Handled = true;
        }

        private void Connector_Loaded(object sender, RoutedEventArgs e)
        {
            _documentView = VisualHelper.FindParent<DocumentView>(this);
            var parentUserControl = VisualHelper.FindParent<DragableUserControl>(this);
            BaseElementViewModel viewModel = parentUserControl.DataContext as BaseElementViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Incorrect Data Context. Failed to create Connector");
            }
            _viewModel = new ConnectorViewModel(viewModel, GetPlacement());
            DataContext = _viewModel;
        }

        private void Connector_LayoutUpdated(object sender, EventArgs e)
        {
            BaseElementView elementView = VisualHelper.FindParent<BaseElementView>(this);
            if (elementView != null && _viewModel != null)
            {
                BaseElementViewModel parentViewModel = elementView.DataContext as BaseElementViewModel;
                if (parentViewModel == null)
                {
                    return;
                }
                double left = parentViewModel.Left;
                double top = parentViewModel.Top;
                Point relative = this.TranslatePoint(new Point(0, 0), elementView);
                left += relative.X + ActualWidth / 2;
                top += relative.Y + ActualHeight / 2;
                _viewModel.Position = new Point(left, top);
            }
        }

        private Placemement GetPlacement()
        {
            Placemement result = Placemement.Left;
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    result = Placemement.Left;
                    break;
                case HorizontalAlignment.Right:
                    result = Placemement.Right;
                    break;

            }
            switch (VerticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    result = Placemement.Bottom;
                    break;
                case VerticalAlignment.Top:
                    result = Placemement.Top;
                    break;
            }
            return result;
        }
    }
}
