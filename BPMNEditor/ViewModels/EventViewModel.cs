using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.ViewModels.Command;

namespace BPMNEditor.ViewModels
{
    public class EventViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 40;
        public const double InitialHeight = 40;

        private Event _event;

        private EventType _type;

        public EventType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyOfPropertyChange(nameof(Type));
            }
        }

        public ICommand ChangeTypeCommand { get; }


        public EventViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(Event), typeof(Task), typeof(Gateway) };
            ChangeTypeCommand = new RelayCommand(type => ChangeType((EventType)type));
        }

        protected override IBaseElement CreateElement()
        {
            _event = new Event();
            return _event;
        }

        protected override HashSet<Type> ApplicableTypes { get; }

        private void ChangeType(EventType type)
        {
            PropertyChangedAction action = new PropertyChangedAction(this, Type, type, nameof(Type));
            NotifyActionPerformed(action);
            Type = type;

        }
    }
}
