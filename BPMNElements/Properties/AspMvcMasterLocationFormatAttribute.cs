using System;

namespace BPMNElements.Properties
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class AspMvcMasterLocationFormatAttribute : Attribute
    {
        public AspMvcMasterLocationFormatAttribute([NotNull] string format)
        {
            Format = format;
        }

        [NotNull] public string Format { get; private set; }
    }
}