using System;
using System.Collections.Generic;

namespace BPMNCore.ViewModels
{
    public class TrackerViewModel : BaseElementViewModel
    {
        private bool _isTrackerVisibile;
        private Type _transferType;

        public TrackerViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>();
            BaseElement = new VisualElement();
        }

        public bool IsTrackerVisible
        {
            get { return _isTrackerVisibile; }
            set
            {
                _isTrackerVisibile = value;
                NotifyOfPropertyChange(nameof(IsTrackerVisible));
            }
        }

        public Type TransferType
        {
            get { return _transferType; }
            set
            {
                _transferType = value;
                NotifyOfPropertyChange(nameof(TransferType));
            }
        }

        protected override VisualElement CreateElement()
        {
            return null;
        }

        protected override HashSet<Type> ApplicableTypes { get; }

        public override bool IsSelectableByUser => false;
    }
}
