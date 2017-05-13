using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Serialization
{
    public class MapperNotFoundException : Exception
    {
        public Type ObjectType { get; }

        public MapperNotFoundException(Type objectType)
        {
            ObjectType = objectType;
        }

        public override string Message => string.Format("Mapper for type {0} not found", ObjectType.Name);
    }

    public class BaseElementNotFoundException : Exception
    {

        public BaseElementNotFoundException(KeyNotFoundException exception) : base("BaseElement not found", exception)
        {

        }
    }
}
