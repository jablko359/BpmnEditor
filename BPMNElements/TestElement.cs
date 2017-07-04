using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Tools;

namespace BPMNElements
{
    [ElementViewModel(typeof(TestViewModel), 50, 50)]
    [ToolboxVisibile]
    public class TestElement : VisualElement
    {
    }

    public class TestViewModel
    {
        
    }
}
