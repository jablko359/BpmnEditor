using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNCore
{
    public class ToolboxPresenterAttribute : Attribute
    {
        public Type PresenterType { get; }

        public ToolboxPresenterAttribute(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}
