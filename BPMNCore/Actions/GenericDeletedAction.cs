namespace BPMNCore.Actions
{
    public class GenericDeletedAction<T> : IAction where T : IInsertable
    {
        private readonly T _deletedItem;
        private readonly IElementsContainer<T> _container;

        public GenericDeletedAction(IElementsContainer<T> container, T deletedItem)
        {
            _container = container;
            _deletedItem = deletedItem;
            Name = $"Element deleted to {_container.GetType()}";
        }

        public string Name { get; }
        public void Revert()
        {
            _container.Items.Add(_deletedItem);
            _deletedItem.AfterInsert();
        }

        public IAction GetInverseAction()
        {
            return new GenericAddedAction<T>(_container, _deletedItem);
        }
    }
}
