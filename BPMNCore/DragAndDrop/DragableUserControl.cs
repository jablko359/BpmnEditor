using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BPMNCore.Views;

namespace BPMNCore.DragAndDrop
{
    public abstract class DragableUserControl : UserControl
    {
        private bool _isMouseDown;
        private Panel _parentPanel;
        protected Point DragStartPoint = new Point();

        protected DragableUserControl()
        {
            MouseLeave += DragableUserControl_MouseLeave;
            MouseLeftButtonDown += DragableUserControl_MouseLeftButtonDown;
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
            e.Handled = true;
        }

        private void DragableUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _parentPanel = VisualHelper.FindParent<Grid>(this);
            MouseMove += DragableUserControl_MouseMove;
        }


        private void DragableUserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isMouseDown)
            {
                StopDrag();
            }
            _isMouseDown = false;
            ReleaseMouseCapture();
            e.Handled = true;
        }

        private void DragableUserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            IMovable movable = element?.DataContext as IMovable;
            if (!IsConnector(e.OriginalSource) && movable?.CanMove == true)
            {
                _isMouseDown = true;
                DragStartPoint = e.GetPosition(this);
                StartDrag();
                CaptureMouse();
                e.Handled = true;
            }
            
        }

        private bool IsConnector(object orginalSource)
        {
            bool result = false;
            FrameworkElement orginalSourceControl = orginalSource as FrameworkElement;
            if (orginalSourceControl != null)
            {
                result = orginalSourceControl.TemplatedParent is Connector;
                result |= orginalSourceControl.TemplatedParent is IResizable;
            }
            return result;
        }

        protected abstract void DoDrag(double x, double y);

        protected abstract void StartDrag();

        protected abstract void StopDrag();

    }
}
