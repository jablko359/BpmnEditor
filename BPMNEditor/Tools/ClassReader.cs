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
        private readonly string _assembly;
        private readonly Func<Type, bool> _conditionFunc;

        public ClassReader(string assembly, Func<Type, bool> condition)
        {
            _assembly = assembly;
            _conditionFunc = condition;
        }

        public ClassReader(string assembly) : this(assembly, null)
        {
        }

        public ClassReader() : this(null)
        {
        }

        public List<Type> GetTypes()
        {
            var previewList =
                GetAssembly().GetExportedTypes().Where(item => item.IsClass);
            if (_conditionFunc != null)
            {
                previewList = previewList.Where(_conditionFunc);
            }
            return previewList.ToList();
        }

        private Assembly GetAssembly()
        {
            Assembly result = null;
            if (_assembly != null)
            {
                result = Assembly.LoadFile(_assembly);
            }
            else
            {
                result = Assembly.GetExecutingAssembly();
            }
            return result;
        }
    }
}
