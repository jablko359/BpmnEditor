﻿using System.Windows;
using BPMNCore.ViewModels;

namespace BPMNCore.Actions
{
    public class ElementMoveAction : BaseElementAction
    {
        private readonly Point _from;
        private readonly Point _to;

        public ElementMoveAction(BaseElementViewModel baseElementViewModel, Point from, Point to) : base(baseElementViewModel)
        {
            Name = $"Moved {BaseElementViewModel}";
            _from = from;
            _to = to;
        }

        public override string Name { get; }
        public override void Revert()
        {
            BaseElementViewModel.Left = _from.X;
            BaseElementViewModel.Top = _from.Y;
        }

        public override IAction GetInverseAction()
        {
            return new ElementMoveAction(BaseElementViewModel, _to, _from);
        }
    }
}
