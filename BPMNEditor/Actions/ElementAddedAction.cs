using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Actions
{
    public class ElementAddedAction : BaseElementAction
    {

        public ElementAddedAction(BaseElementViewModel baseElementViewModel) : base(baseElementViewModel)
        {
            Name = string.Format("Added {0}", baseElementViewModel.BaseElement);
        }

        public override void Revert()
        {
            BaseElementViewModel.Document.BaseElements.Remove(BaseElementViewModel);
        }

        public override string Name { get; }
        public override IAction GetInverseAction()
        {
            return new ElementDeletedAction(BaseElementViewModel);
        }
    }
}
