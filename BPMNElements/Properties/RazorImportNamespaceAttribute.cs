using System;

namespace BPMNElements.Properties
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RazorImportNamespaceAttribute : Attribute
    {
        public RazorImportNamespaceAttribute([NotNull] string name)
        {
            Name = name;
        }

        [NotNull] public string Name { get; private set; }
    }
}