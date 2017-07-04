using System;

namespace BPMNCore.DragAndDrop
{
    public class DraggableAttribute : Attribute
    {
        public Type DataType { get; }

        public DraggableAttribute(Type dataType)
        {
            DataType = dataType;
        }
    }
}
