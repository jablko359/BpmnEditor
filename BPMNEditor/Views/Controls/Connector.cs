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

        public static double Offset = 10;

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
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            BaseElementView elementView = VisualHelper.FindParent<BaseElementView>(this);
            var viewModel = this.DataContext as ConnectorViewModel;
            if (elementView != null && viewModel != null)
            {
                BaseElementViewModel parentViewModel = elementView.DataContext as BaseElementViewModel;
                if (parentViewModel == null)
                {
                    return;
                }
                double left = parentViewModel.Left;
                double top = parentViewModel.Top;
                Point relative = CalculateRelativePoint(parentViewModel); //this.TranslatePoint(new Point(0, 0), elementView);
                left += relative.X;
                top += relative.Y;
                Point pt = new Point(left, top);
                viewModel.Position = pt;
            }
        }

        private Point CalculateRelativePoint(VisualElementViewModel visualElementViewModel)
        {
            Point result = new Point();
            var viewModel = this.DataContext as ConnectorViewModel;
            if (viewModel != null)
            {
                switch (viewModel.Placemement)
                {
                    case Placemement.Bottom:
                        result.X = visualElementViewModel.Width / 2;
                        result.Y = visualElementViewModel.Height + Offset;
                        break;
                    case Placemement.Left:
                        result.X = -Offset;
                        result.Y = visualElementViewModel.Height / 2;
                        break;
                    case Placemement.Right:
                        result.X = visualElementViewModel.Width + Offset;
                        result.Y = visualElementViewModel.Height / 2;
                        break;
                    case Placemement.Top:
                        result.X = visualElementViewModel.Width / 2;
                        result.Y = -Offset;
                        break;
                }
            }
            return result;
        }
    }
}
