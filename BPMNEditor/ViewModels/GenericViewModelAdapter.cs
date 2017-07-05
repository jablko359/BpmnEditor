using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;

namespace BPMNEditor.ViewModels
{
    public class GenericViewModelAdapter : BaseElementViewModel
    {
        private readonly Type _modelType;
        private VisualElement _visualElement;

        public GenericViewModelAdapter(DocumentViewModel documentViewModel, Type modelType) : base(documentViewModel)
        {
            
            _modelType = modelType;
        }

        protected override HashSet<Type> ApplicableTypes { get; }
        protected override VisualElement CreateElement()
        {
            _visualElement = Activator.CreateInstance(_modelType) as VisualElement;
            return _visualElement;
        }
    }
}
