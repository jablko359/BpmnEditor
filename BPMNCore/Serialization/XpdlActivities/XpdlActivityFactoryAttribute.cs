using System;

namespace BPMNCore.Serialization.XpdlActivities
{
    public class XpdlActivityFactoryAttribute : Attribute
    {
        public Type ActivityFactoryType { get; private set; }

        public IActivityFactory Factory { get; private set; }

        public XpdlActivityFactoryAttribute(Type factoryType)
        {
            if (!typeof(IActivityFactory).IsAssignableFrom(factoryType))
            {
                throw new ArgumentException(string.Format("{0} must implement IActivityFactory interface", factoryType.Name));
            }
            if (factoryType.IsAbstract)
            {
                throw new ArgumentException(string.Format("{0} can not be abstract", factoryType.Name));
            }
            ActivityFactoryType = factoryType;
            Factory = Activator.CreateInstance(factoryType) as IActivityFactory;
        }
    }
}