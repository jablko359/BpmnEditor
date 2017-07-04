using System.Windows;
using BPMNCore.ViewModels;

namespace BPMNCore.Actions
{
    public class ElementResizeAction : BaseElementAction
    {
        private readonly Rect _from;
        private readonly Rect _to;

        public ElementResizeAction(BaseElementViewModel baseElementViewModel, Rect from, Rect to) : base(baseElementViewModel)
        {
            Name = $"{BaseElementViewModel} resized";
            _from = from;
            _to = to;
        }

        public override string Name { get; }
        public override void Revert()
        {
            BaseElementViewModel.Left = _from.Left;
            BaseElementViewModel.Top = _from.Top;
            BaseElementViewModel.Height = _from.Height;
            BaseElementViewModel.Width = _from.Width;
        }

        public override IAction GetInverseAction()
        {
            return new ElementResizeAction(BaseElementViewModel, _to, _from);
        }
    }
}
