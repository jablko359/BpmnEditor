using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace BPMNEditor.Tools.DragAndDrop
{
    public class ElementDropBehavior : Behavior<FrameworkElement>
    {
        private Type _transferedType;


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += AssociatedObjectOnDragEnter;
            AssociatedObject.DragOver += AssociatedObjectOnDragOver;
            AssociatedObject.DragLeave += AssociatedObjectOnDragLeave;
            AssociatedObject.Drop += AssociatedObjectOnDrop;
        }
       

        private void AssociatedObjectOnDrop(object sender, DragEventArgs dragEventArgs)
        {
            if (_transferedType != null && dragEventArgs.Data.GetDataPresent(_transferedType))
            {
                var data = dragEventArgs.Data.GetData(_transferedType);
                dragEventArgs.Effects = DragDropEffects.Move;
                IDropable dropable = AssociatedObject.DataContext as IDropable;
                if (dropable != null)
                {
                    var position = dragEventArgs.GetPosition(AssociatedObject);
                    dropable.Drop(data,position.X,position.Y);
                }
            }

        }

        private void AssociatedObjectOnDragLeave(object sender, DragEventArgs dragEventArgs)
        {

        }

        private void AssociatedObjectOnDragOver(object sender, DragEventArgs dragEventArgs)
        {
            if (_transferedType != null && dragEventArgs.Data.GetDataPresent(_transferedType))
            {
                var data = dragEventArgs.Data.GetData(_transferedType);
                dragEventArgs.Effects = DragDropEffects.Move;
                IDropable dropable = AssociatedObject.DataContext as IDropable;
                if (dropable != null)
                {
                    var position = dragEventArgs.GetPosition(AssociatedObject);
                    dropable.DragOver(position.X, position.Y, data);
                }
            }
        }

        private void AssociatedObjectOnDragEnter(object sender, DragEventArgs dragEventArgs)
        {
            if (_transferedType == null && AssociatedObject != null)
            {
                IDropable dropable = AssociatedObject.DataContext as IDropable;
                if (dropable != null)
                {
                    _transferedType = dropable.DataType;
                }
            }
        }
    }
}
