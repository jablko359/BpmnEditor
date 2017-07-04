using System.Collections.Generic;

namespace BPMNCore.Actions
{
    public interface IElementsContainer<T>
    {
        IList<T> Items { get; }
    }
}