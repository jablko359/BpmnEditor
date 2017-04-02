using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class TaskViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 128;
        public const double InitialHeight = 80;

        private Task _task;

        public TaskViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(Event), typeof(Task), typeof(Gateway) };
        }

        protected override IBaseElement CreateElement()
        {
            _task = new Task();
            return _task;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
    }
}
