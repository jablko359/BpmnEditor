using System;

namespace BPMNEditor.Serialization.XpdlActivities
{
    public class EnumNotFoundException : Exception
    {
        public Type EnumType { get; }
        public Type ObjectType { get; }

        public EnumNotFoundException(Type enumType, Type objectType)
        {
            EnumType = enumType;
            ObjectType = objectType;
        }

        public override string Message => string.Format("No corresponding enum ({0}) for type {1}", EnumType, ObjectType);
    }
}