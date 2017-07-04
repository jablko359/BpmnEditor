using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace BPMNCore.DragAndDrop
{
    public class ElementDragBehavior : Behavior<FrameworkElement>
    {
        private bool _isMouseDown;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObjectOnMouseLeftButtonUp;
            AssociatedObject.MouseLeave += AssociatedObjectOnMouseLeave;
        }

        private void AssociatedObjectOnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
        {
            if (_isMouseDown)
            {
                var dragable = AssociatedObject.DataContext as IDragable;
                if (dragable != null)
                {
                    DataObject transferObject = new DataObject();
                    transferObject.SetData(dragable.DataType, AssociatedObject.DataContext);
                    DragDrop.DoDragDrop(AssociatedObject, transferObject, DragDropEffects.Move);
                }
            }
            _isMouseDown = false;
        }

        private void AssociatedObjectOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _isMouseDown = false;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _isMouseDown = true;
        }
    }
}
