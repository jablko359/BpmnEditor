using System;

namespace BPMNCore
{
    public abstract class IdElement : IBaseElement
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        protected IdElement()
        {
            Guid = Guid.NewGuid();
        }

        public IdElement(string name) : this()
        {
            Name = name;
        }

        public string GetId()
        {
            return Guid.ToString();
        }

        
       
    }
}
