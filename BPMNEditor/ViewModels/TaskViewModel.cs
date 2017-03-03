using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class TaskViewModel : BaseElementViewModel
    {
        public const double InitialWidth = 128;
        public const double InitialHeight = 80;

        private Task _task;

        protected override IBaseElement CreateElement()
        {
            _task = new Task();
            return _task;
        }
    }
}
