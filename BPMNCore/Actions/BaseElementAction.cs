using BPMNCore.ViewModels;

namespace BPMNCore.Actions
{
    public abstract class BaseElementAction : IAction
    {
        protected BaseElementViewModel BaseElementViewModel;

        protected BaseElementAction(BaseElementViewModel baseElementViewModel)
        {
            BaseElementViewModel = baseElementViewModel;
        }

        public abstract string Name { get; }
        public abstract void Revert();
        public abstract IAction GetInverseAction();

        public override string ToString()
        {
            return Name;
        }
    }
}
