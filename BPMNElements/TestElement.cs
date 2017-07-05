using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Tools;

namespace BPMNElements
{
    [CustomModel]
    [ToolboxVisibile]
    public class TestElement : VisualElement
    {
        public TestElement()
        {
            Height = 200;
            Width = 100;
        }
    }

    
}
