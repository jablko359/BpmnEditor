using System.Windows;
using BPMNCore.Converters;

namespace BPMNCore.ViewModels
{
    public class ConnectorViewModel : ConnectorBase
    {
        public static double Offset = 10;
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

        public void UpdatePosition()
        {
            if (_parentViewModel == null)
            {
                return;
            }
            double left = _parentViewModel.Left;
            double top = _parentViewModel.Top;
            Point relative = CalculateRelativePoint(_parentViewModel); //this.TranslatePoint(new Point(0, 0), elementView);
            left += relative.X;
            top += relative.Y;
            Point pt = new Point(left, top);
            Position = pt;
        }

        private Point CalculateRelativePoint(VisualElementViewModel visualElementViewModel)
        {
            Point result = new Point();
            switch (Placemement)
            {
                case Placemement.Bottom:
                    result.X = visualElementViewModel.Width / 2;
                    result.Y = visualElementViewModel.Height + Offset;
                    break;
                case Placemement.Left:
                    result.X = -Offset;
                    result.Y = visualElementViewModel.Height / 2;
                    break;
                case Placemement.Right:
                    result.X = visualElementViewModel.Width + Offset;
                    result.Y = visualElementViewModel.Height / 2;
                    break;
                case Placemement.Top:
                    result.X = visualElementViewModel.Width / 2;
                    result.Y = -Offset;
                    break;
            }
            return result;
        }
    }
}
