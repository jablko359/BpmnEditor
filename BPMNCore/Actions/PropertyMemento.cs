namespace BPMNCore.Actions
{
    public class PropertyMemento
    {
        public object Value { get; }    
        public string Name { get; }

        public PropertyMemento(object value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
