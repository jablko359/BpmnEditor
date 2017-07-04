using System;

namespace BPMNCore.DragAndDrop
{
    public interface ITypeProvider
    {
        Type ElementType { get; }
    }
}