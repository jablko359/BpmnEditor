using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BPMNEditor.Views;
using BPMNEditor.Views.Controls;

namespace BPMNEditor.Tools.DragAndDrop
{
    public abstract class DragableUserControl : UserControl
    {
        private bool _isMouseDown;
        private Panel _parentPanel;

        protected DragableUserControl()
        {
            MouseLeave += DragableUserControl_MouseLeave;
            PreviewMouseLeftButtonDown += DragableUserControl_MouseLeftButtonDown;
            MouseLeftButtonUp += DragableUserControl_MouseLeftButtonUp;
            Loaded += DragableUserControl_Loaded;
        }

        private void DragableUserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void DragableUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point newPosition = e.GetPosition(_parentPanel);
                DoDrag(newPosition.X, newPosition.Y);
            }

        }

        private void DragableUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _parentPanel = VisualHelper.FindParent<Grid>(this);
            MouseMove += DragableUserControl_MouseMove;
        }


        private void DragableUserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            ReleaseMouseCapture();
        }

        private void DragableUserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsConnector(e.OriginalSource))
            {
                _isMouseDown = true;
                CaptureMouse();
            }

        }

        private bool IsConnector(object orginalSource)
        {
            bool result = false;
            FrameworkElement orginalSourceControl = orginalSource as FrameworkElement;
            if (orginalSourceControl != null)
            {
                result = orginalSourceControl.TemplatedParent is Connector;
                result |= orginalSourceControl.TemplatedParent is ResizeThumb;
            }
            return result;
        }

        protected abstract void DoDrag(double x, double y);
        
    }
}
