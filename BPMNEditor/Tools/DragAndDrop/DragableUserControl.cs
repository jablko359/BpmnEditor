using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BPMNEditor.Tools.DragAndDrop
{
    public abstract class DragableUserControl : UserControl
    {
        private bool _isMouseDown;
        private Panel _parentPanel;

        protected DragableUserControl()
        {
            MouseLeave += DragableUserControl_MouseLeave;
            MouseLeftButtonDown += DragableUserControl_MouseLeftButtonDown;
            MouseLeftButtonUp += DragableUserControl_MouseLeftButtonUp;
            Loaded += DragableUserControl_Loaded;
        }

        private void DragableUserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void DragableUserControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point newPosition = e.GetPosition(_parentPanel);
                DoDrag(newPosition.X, newPosition.Y);
            }
            
        }

        private void DragableUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _parentPanel = FindParent<Grid>(this);
             MouseMove += DragableUserControl_MouseMove;
        }
        
       
        private void DragableUserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            this.ReleaseMouseCapture();
        }

        private void DragableUserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            this.CaptureMouse();
        }

        protected abstract void DoDrag(double x, double y);

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }
    }
}
