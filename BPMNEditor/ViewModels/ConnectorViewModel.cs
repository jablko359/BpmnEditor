using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.ViewModels.Converters;

namespace BPMNEditor.ViewModels
{
    public class ConnectorViewModel : ConnectorBase
    {

        private readonly BaseElementViewModel _parentViewModel;

        private bool _isVisible = true;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(nameof(IsVisible));
            }
        }


        public BaseElementViewModel Parent
        {
            get { return _parentViewModel; }
        }

        public ConnectorViewModel(BaseElementViewModel baseElementViewModel, Placemement placemement) : base(placemement)
        {
            _parentViewModel = baseElementViewModel;
        }

        public void ConnectorStart()
        {
            _parentViewModel.ConnectorStart(this);
        }

        public override Rect GetParentRectWithMargin(double margin)
        {
            var rect = new Rect(Parent.Left, Parent.Top, Parent.Width, Parent.Height);
            rect.Inflate(margin, margin);
            return rect;
        }

        public Rect GetRectWithMargin(double margin)
        {
            PointToRectangleConverter converter = new PointToRectangleConverter();
            Rect result = (Rect)converter.Convert(Position, typeof(Rect), null, null);
            return result;
        }
    }

    public enum Placemement
    {
        Left = 0, Top = 1, Right = 2, Bottom = 3, None
    }
}
