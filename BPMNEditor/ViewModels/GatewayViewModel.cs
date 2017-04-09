using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class GatewayViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 40;
        public const double InitialHeight = 40;

        private Gateway _gateway;

        


        public GatewayViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(Event), typeof(Task), typeof(Gateway) };
        }

        protected override IBaseElement CreateElement()
        {
           _gateway = new Gateway();
            return _gateway;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
    }
}
