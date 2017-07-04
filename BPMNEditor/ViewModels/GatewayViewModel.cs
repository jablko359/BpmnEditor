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
    public class GatewayViewModel : PoolElementViewModel
    {
        public const double InitialWidth = 50;
        public const double InitialHeight = 50;

        private GatewayElement _gatewayElement;

        #region Properties

        public GatewayType Type
        {
            get { return _gatewayElement.Type; }
            set
            {
                _gatewayElement.Type = value;
                NotifyOfPropertyChange(nameof(Type));
            }
        }

        [Browsable(false)]
        public ICommand ChangeTypeCommand { get; }

        #endregion


        public GatewayViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(EventElement), typeof(TaskElement), typeof(GatewayElement) };
            ChangeTypeCommand = new RelayCommand(type => ChangeType((GatewayType)type));
        }

        protected override VisualElement CreateElement()
        {
           _gatewayElement = new GatewayElement();
            return _gatewayElement;
        }

        protected override HashSet<Type> ApplicableTypes { get; }

        private void ChangeType(GatewayType type)
        {
            PropertyChangedAction action = new PropertyChangedAction(this, Type, type, nameof(Type));
            NotifyActionPerformed(action);
            Type = type;
        }

        protected override void SetElement(VisualElement element)
        {
            GatewayElement gateway = element as GatewayElement;
            _gatewayElement = gateway; 
            base.SetElement(element);
        }
    }
}
