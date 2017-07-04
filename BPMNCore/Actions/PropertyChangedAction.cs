using System;
using System.Reflection;
using BPMNCore.ViewModels;

namespace BPMNCore.Actions
{
    public class PropertyChangedAction : BaseElementAction
    {
        private readonly object _oldValue;
        private readonly object _newValue;
        private readonly string _propertyName;

        public PropertyChangedAction(BaseElementViewModel viewModel, object oldValue, object newValue, string propertyName) : base(viewModel)
        {
            _oldValue = oldValue;
            _newValue = newValue;
            _propertyName = propertyName;
        }

        public override string Name => $"{_propertyName} changed";
        public override void Revert()
        {
            Type viewModelType = BaseElementViewModel.GetType();
            PropertyInfo property = viewModelType.GetProperty(_propertyName);
            if (property != null)
            {
                property.SetValue(BaseElementViewModel, _oldValue);
            }
        }

        public override IAction GetInverseAction()
        {
            return new PropertyChangedAction(BaseElementViewModel, _newValue, _oldValue, _propertyName);
        }
    }
}
