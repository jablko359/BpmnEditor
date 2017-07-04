using System;

namespace BPMNCore.DragAndDrop
{
    public interface IDragable
    {
        /// <summary>
        /// Transfered data type
        /// </summary>
        Type DataType { get; }
    }
}
