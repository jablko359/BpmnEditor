using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Actions
{
    public class ElementMoveAction : IAction
    {
        private BaseElementViewModel _baseElementViewModel;

        public ElementMoveAction(BaseElementViewModel baseElementViewModel)
        {
            _baseElementViewModel = baseElementViewModel;
        }

        public string Name { get; }
        public void Revert()
        {
            throw new NotImplementedException();
        }

        public IAction GetInverseAction()
        {
            throw new NotImplementedException();
        }
    }
}
