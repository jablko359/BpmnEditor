using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Actions
{
    public class PropertyChagnedAction : BaseElementAction
    {
        private readonly object _oldValue;
        private readonly object _newValue;
        private readonly string _propertyName;

        public PropertyChagnedAction(BaseElementViewModel viewModel, object oldValue, object newValue, string propertyName) : base(viewModel)
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
            return new PropertyChagnedAction(BaseElementViewModel, _newValue, _oldValue, _propertyName);
        }
    }
}
