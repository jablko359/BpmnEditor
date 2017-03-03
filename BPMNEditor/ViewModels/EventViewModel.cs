using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class EventViewModel : BaseElementViewModel
    {
        public const double InitialWidth = 40;
        public const double InitialHeight = 40;

        private Event _event;

        protected override IBaseElement CreateElement()
        {
            _event = new Event();
            return _event;
        }
    }
}
