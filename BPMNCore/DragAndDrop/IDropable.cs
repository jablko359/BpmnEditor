using System;

namespace BPMNCore.DragAndDrop
{
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
}