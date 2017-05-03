﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNEditor.Models.Elements
{
    public abstract class VisualElement : IdElement
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
