using System;
using System.Collections.Generic;

namespace BPMNCore.Serialization.XpdlActivities
{
    public class ActivityMapperAttribute : Attribute
    {
        private static readonly Dictionary<Type, IActivityMapper> RegisteredMappers = new Dictionary<Type, IActivityMapper>();

        private readonly Type _elementType;
        private readonly Type _mapperType;

        public ActivityMapperAttribute(Type elementType, Type mapperType)
        {
            if (!typeof(IActivityMapper).IsAssignableFrom(mapperType))
            {
                throw new ArgumentException(string.Format("IActivityMapper is not assignalbe from {0}", mapperType));
            }
            _elementType = elementType;
            _mapperType = mapperType;
        }

        public void Register()
        {
            IActivityMapper mapper = Activator.CreateInstance(_mapperType) as IActivityMapper;
            RegisteredMappers.Add(_elementType, mapper);
        }

        public static IActivityMapper GetMapper(Type elementType)
        {
            if (RegisteredMappers.ContainsKey(elementType))
            {
                return RegisteredMappers[elementType];
            }
            return null;
        }
    }
}
