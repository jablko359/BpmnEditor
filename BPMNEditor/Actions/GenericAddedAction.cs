using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Actions
{
    public class GenericAddedAction<T> : IAction
    {
        private readonly T _addedItem;
        private readonly IElementsContainer<T> _container;

        public GenericAddedAction(IElementsContainer<T> container, T addedItem)
        {
            _container = container;
            _addedItem = addedItem;
            Name = $"Element added to {_container.GetType()}";
        }

        public string Name { get; }
        public void Revert()
        {
            _container.Items.Remove(_addedItem);
        }

        public IAction GetInverseAction()
        {
            return new GenericDeletedAction<T>(_container, _addedItem);
        }
    }

    public interface IElementsContainer<T>
    {
        IList<T> Items { get; }
    }
}
