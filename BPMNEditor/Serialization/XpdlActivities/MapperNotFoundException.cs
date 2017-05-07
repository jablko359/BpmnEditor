using System;

namespace BPMNEditor.Serialization.XpdlActivities
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
}