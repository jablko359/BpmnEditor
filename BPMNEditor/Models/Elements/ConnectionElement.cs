using BPMNCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BPMNEditor.Models.Elements
{
    public class ConnectionElement : IdElement
    {
        public IBaseElement SourceElement { get; }
        public IBaseElement TargetElement { get; }
        public List<Point> Points { get; set; }

        public ConnectionElement(IBaseElement sourceElement, IBaseElement targetElement)
        {
            Points = new List<Point>();
            SourceElement = sourceElement;
            TargetElement = targetElement;
        }

    }
}
