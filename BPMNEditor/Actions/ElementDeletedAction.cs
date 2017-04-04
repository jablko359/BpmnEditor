using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Actions
{
    public class ElementDeletedAction : BaseElementAction
    {
        public ElementDeletedAction(BaseElementViewModel baseElementViewModel) : base(baseElementViewModel)
        {
            Name = string.Format("Deleted {0}", baseElementViewModel.BaseElement);
        }

        public override string Name { get; }
        public override void Revert()
        {
            BaseElementViewModel.Document.BaseElements.Add(BaseElementViewModel);
        }

        public override IAction GetInverseAction()
        {
            return new ElementAddedAction(BaseElementViewModel);
        }
    }
}
