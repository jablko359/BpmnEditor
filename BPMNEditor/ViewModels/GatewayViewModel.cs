using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
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

        private Gateway _gateway;

        private GatewayType _type;

        #region Properties

        public GatewayType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyOfPropertyChange(nameof(Type));
            }
        }

        [Browsable(false)]
        public ICommand ChangeTypeCommand { get; }

        #endregion


        public GatewayViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(Event), typeof(Task), typeof(Gateway) };
            ChangeTypeCommand = new RelayCommand(type => ChangeType((GatewayType)type));
        }

        protected override IBaseElement CreateElement()
        {
           _gateway = new Gateway();
            return _gateway;
        }

        protected override HashSet<Type> ApplicableTypes { get; }

        private void ChangeType(GatewayType type)
        {
            PropertyChangedAction action = new PropertyChangedAction(this, Type, type, nameof(Type));
            NotifyActionPerformed(action);
            Type = type;
        }
    }
}
