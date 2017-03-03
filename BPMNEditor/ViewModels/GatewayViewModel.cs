using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class GatewayViewModel : BaseElementViewModel
    {
        public const double InitialWidth = 40;
        public const double InitialHeight = 40;

        private Gateway _gateway;

        protected override IBaseElement CreateElement()
        {
           _gateway = new Gateway();
            return _gateway;
        }
    }
}
