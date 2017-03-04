using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BPMNEditor.Tools.DragAndDrop
{
    public interface IDragable
    {
        /// <summary>
        /// Transfered data type
        /// </summary>
        Type DataType { get; }
    }

    public interface IDropable
    {
        /// <summary>
        /// Data type that can be dropped on a target
        /// </summary>
        Type DataType { get; }
        /// <summary>
        /// Drop scenario
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Drop(object data, double x = 0, double y = 0);
        /// <summary>
        /// Informs view model about drag
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dragItem"></param>
        void DragOver(double x, double y, object dragItem);

        void DragLeave();
    }

    public interface IResizableObject
    {
        double Width { get; set; }
        double Height { get; set; }
        double Left { get; set; }
        double Top { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
    }

    public interface IMovable
    {
        void Move(double x, double y);
        double Left { get; }
        double Top { get; }
    }

    public interface ITypeProvider
    {
        Type ElementType { get; }
    }
}
