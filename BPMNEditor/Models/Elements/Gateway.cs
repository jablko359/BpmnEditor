﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    [Draggable(typeof(IDocumentElement))]
    [ElementViewModel(typeof(GatewayViewModel), GatewayViewModel.InitialWidth, GatewayViewModel.InitialHeight)]
    public class Gateway : IBaseElement
    {
        
    }

    public enum GatewayType
    {
        None, Or, Xor, EventBased, Parallel
    }
    
}
