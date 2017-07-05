using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.Tools
{
    public class ClassReader
    {
        private readonly string _assemblyName;
        private readonly Func<Type, bool> _conditionFunc;
        private readonly Assembly _assembly;
       

        public ClassReader(string assemblyName, Func<Type, bool> condition)
        {
            _assemblyName = assemblyName;
            _conditionFunc = condition;
            _assembly = GetAssembly();
        }

        public ClassReader(string assemblyName) : this(assemblyName, null)
        {
        }

        public ClassReader() : this(null)
        {
        }

        public List<Type> GetTypes()
        {
            
            var previewList =
                _assembly.GetExportedTypes().Where(item => item.IsClass);
            if (_conditionFunc != null)
            {
                previewList = previewList.Where(_conditionFunc);
            }
            return previewList.ToList();
        }

        public void LoadResources()
        {
            var stream = _assembly.GetManifestResourceStream(_assembly.GetName().Name + ".g.resources");
            if (stream == null)
            {
                return;
            }
            var resourceReader = new ResourceReader(stream);

            foreach (DictionaryEntry resource in resourceReader)
            {
                if (new FileInfo(resource.Key.ToString()).Extension.Equals(".baml"))
                {
                    Uri uri = new Uri("/" + _assembly.GetName().Name + ";component/" + resource.Key.ToString().Replace(".baml", ".xaml"), UriKind.Relative);
                    ResourceDictionary skin = Application.LoadComponent(uri) as ResourceDictionary;
                    Application.Current.Resources.MergedDictionaries.Add(skin);
                }
            }
        }

        private Assembly GetAssembly()
        {
            Assembly result = null;
            if (_assemblyName != null)
            {
                result = Assembly.LoadFile(_assemblyName);
            }
            else
            {
                result = Assembly.GetExecutingAssembly();
            }
            return result;
        }
    }
}
