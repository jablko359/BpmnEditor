using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public class EventViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 40;
        public const double InitialHeight = 40;

        private Event _event;

        public EventViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() {typeof(Event), typeof(Task), typeof(Gateway)};
        }

        protected override IBaseElement CreateElement()
        {
            _event = new Event();
            return _event;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
    }
}
