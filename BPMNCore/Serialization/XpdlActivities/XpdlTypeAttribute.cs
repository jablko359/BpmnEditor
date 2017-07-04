using System;
using System.Reflection;

namespace BPMNCore.Serialization.XpdlActivities
{
    public class XpdlTypeAttribute : Attribute
    {
        public Type XpdlType { get; }

        public XpdlTypeAttribute(Type xpdlType)
        {
            XpdlType = xpdlType;
        }

        public static Type GetCorrespondingType<T>(T enumType) where T : struct, IConvertible
        {
            Type result = null;
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var type = typeof(T);
            var memberInfo = type.GetMember(enumType.ToString());
            if (memberInfo.Length > 0)
            {
                XpdlTypeAttribute attribute = memberInfo[0].GetCustomAttribute(typeof(XpdlTypeAttribute)) as XpdlTypeAttribute;
                if (attribute != null)
                {
                    result = attribute.XpdlType;
                }
            }
            return result;

        }

        public static T GetCorrespondingEnum<T>(Type objectType) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            Type enumType = typeof(T);
            var memberInfos = enumType.GetMembers();
            foreach (var memberInfo in memberInfos)
            {
                XpdlTypeAttribute attribute = memberInfo.GetCustomAttribute(typeof(XpdlTypeAttribute)) as XpdlTypeAttribute;
                if (attribute != null && attribute.XpdlType == objectType)
                {
                    T result = (T)Enum.Parse(enumType, memberInfo.Name);
                    return result;
                }
            }
            throw new EnumNotFoundException(enumType, objectType);
        }
    }
}