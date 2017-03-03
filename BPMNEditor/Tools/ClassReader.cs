using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.Tools
{
    public class ClassReader
    {
        private readonly string _namespace;
        private readonly Func<Type, bool> _conditionFunc;

        public ClassReader(string @namespace, Func<Type, bool> condition)
        {
            _namespace = @namespace;
            _conditionFunc = condition;
        }

        public ClassReader(string @namespace) : this(@namespace, null)
        {
        }

        public List<Type> GetTypes()
        {
            var previewList =
                Assembly.GetExecutingAssembly().GetTypes().Where(item => item.IsClass && item.Namespace == _namespace);
            if (_conditionFunc != null)
            {
                previewList = previewList.Where(_conditionFunc);
            }
            return previewList.ToList();
        }
    }
}
