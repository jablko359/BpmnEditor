using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XPDL.Xpdl;

namespace BPMNCore
{
    public class ActivityMapperAttribute : Attribute
    {
        private static Regex NodeIdRegex = new Regex("BPMNEditor\\(\"(?<name>\\w*)\"\\)");
        private static readonly Dictionary<Type, IActivityMapper> RegisteredMappers = new Dictionary<Type, IActivityMapper>();
        private static readonly Dictionary<string, IActivityMapper> AllMappers = new Dictionary<string, IActivityMapper>();

        private readonly Type _elementType;
        private readonly Type _mapperType;
        public string Name { get; }

        public ActivityMapperAttribute(Type elementType, Type mapperType, string name)
        {
            Name = name;
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
            if (!RegisteredMappers.ContainsKey(_elementType))
            {
                RegisteredMappers.Add(_elementType, mapper);
            }
            string mapperName = Name;
            AllMappers.Add(mapperName, mapper);
        }

        public static IActivityMapper GetMapper(Type elementType)
        {
            if (RegisteredMappers.ContainsKey(elementType))
            {
                return RegisteredMappers[elementType];
            }
            return null;
        }

        public static IActivityMapper GetMapper(NodeGraphicsInfos graphicsInfo)
        {
            if (graphicsInfo != null && graphicsInfo.NodeGraphicsInfo != null)
            {
                foreach (var nodeGraphicsInfo in graphicsInfo.NodeGraphicsInfo)
                {
                    string name = nodeGraphicsInfo.ToolId;
                    var matches = NodeIdRegex.Matches(name);
                    foreach (Match match in matches)
                    {
                        var nameGroup = match.Groups["name"];
                        if (nameGroup.Success)
                        {
                            string key = nameGroup.Value;
                            if (AllMappers.ContainsKey(key))
                            {
                                return AllMappers[key];
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
