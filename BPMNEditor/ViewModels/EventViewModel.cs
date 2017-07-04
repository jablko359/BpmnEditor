using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BPMNCore;
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

        private EventElement _eventElement;

        public EventType Type
        {
            get { return _eventElement.Type; }
            set
            {
                _eventElement.Type = value;
                NotifyOfPropertyChange(nameof(Type));
            }
        }
        [Browsable(false)]
        public ICommand ChangeTypeCommand { get; }


        public EventViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(EventElement), typeof(TaskElement), typeof(GatewayElement) };
            ChangeTypeCommand = new RelayCommand(type => ChangeType((EventType)type));
        }

        protected override VisualElement CreateElement()
        {
            _eventElement = new EventElement();
            return _eventElement;
        }

        protected override HashSet<Type> ApplicableTypes { get; }

        private void ChangeType(EventType type)
        {
            PropertyChangedAction action = new PropertyChangedAction(this, Type, type, nameof(Type));
            NotifyActionPerformed(action);
            Type = type;
        }

        protected override void SetElement(VisualElement element)
        {
            EventElement eventElement = element as EventElement;
            _eventElement = eventElement;
            base.SetElement(element);
        }
    }
}
