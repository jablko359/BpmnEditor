using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Tools
{
    class ClassAssemblyReader
    {
        private readonly StringCollection _assembliesPathCollection;

        public ClassAssemblyReader(StringCollection assemliesPathCollection)
        {
            _assembliesPathCollection = assemliesPathCollection;
        }

        public List<Type> GetTypes()
        {
            List<Type> types = new List<Type>();
            if (_assembliesPathCollection != null)
            {
                foreach (string path in _assembliesPathCollection)
                {
                    ClassReader reader = new ClassReader(path);
                    types.AddRange(reader.GetTypes());
                    reader.LoadResources();
                }
            }
            return types;
        }

       
    }
}
