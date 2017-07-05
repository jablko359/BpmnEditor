using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.ViewModels
{
    public class GenericViewModelAdapter : BaseElementViewModel
    {
        private readonly Type _modelType;
        private VisualElement _visualElement;

        public GenericViewModelAdapter(DocumentViewModel documentViewModel, Type modelType) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>() { typeof(EventElement), typeof(TaskElement), typeof(GatewayElement) };
            _modelType = modelType;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
        protected override VisualElement CreateElement()
        {
            _visualElement = Activator.CreateInstance(_modelType) as VisualElement;
            INotifyPropertyChanged propertyChangedNotifier = _visualElement as INotifyPropertyChanged;
            if (propertyChangedNotifier != null)
            {
                propertyChangedNotifier.PropertyChanged += PropertyChangedNotifier_PropertyChanged;
            }
            return _visualElement;
        }

        private void PropertyChangedNotifier_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine();
        }
    }
}
