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
        private Task _task;

        protected override IBaseElement CreateElement()
        {
            _task = new Task();
            return _task;
        }
    }
}
