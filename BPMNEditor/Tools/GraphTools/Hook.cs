using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools.GraphTools
{
    public class Hook : PropertyChangedBase
    {

        private Point _startPoint;
        private Point _endPoint;

        public bool IsMoved { get; set; }

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

        public Point StartPoint
        {
            get { return _startPoint; }
            private set { _startPoint = value; }
        }

        public Point EndPoint
        {
            get { return _endPoint; }
            private set { _endPoint = value; }
        }

        public Point OriginalStartPoint { get; private set; }
        public Point OriginalEndPoint { get; private set; }

        private readonly ElementsConnectionViewModel _parent;

        public Point HookPoint { get; private set; }
        public Orientation Orientation { get; set; }

        public Hook(Point start, Point end, ElementsConnectionViewModel parent)
        {
            double x = (start.X + end.X) / 2;
            double y = (start.Y + end.Y) / 2;

            _parent = parent;

            OriginalStartPoint = start;
            OriginalEndPoint = end;

            StartPoint = start;
            EndPoint = end;
            HookPoint = new Point(x, y);
            Orientation = GetOrientation(start, end);
        }

        public void MoveHook(double horizontalChange, double verticalChange)
        {
            IsMoved = true;
            Point newHook = new Point();
            switch (Orientation)
            {
                case Orientation.Horizontal:
                    newHook.X = horizontalChange;
                    newHook.Y = HookPoint.Y;
                    _startPoint.X = horizontalChange;
                    _endPoint.X = horizontalChange;
                    break;
                case Orientation.Vertical:
                    newHook.X = HookPoint.X;
                    newHook.Y = verticalChange;
                    _startPoint.Y = verticalChange;
                    _endPoint.Y = verticalChange;
                    break;
            }
            HookPoint = newHook;
            NotifyOfPropertyChange(nameof(HookPoint));
            _parent.HookChange(this);
        }

        public void SetNewPoints()
        {
            OriginalStartPoint = StartPoint;
            OriginalEndPoint = EndPoint;
            double x = (StartPoint.X + EndPoint.X) / 2;
            double y = (StartPoint.Y + EndPoint.Y) / 2;

            
        }

        public void HookDragEnd()
        {
            _parent.RecalculateHooks();
        }

        public static Orientation GetOrientation(Point startPoint, Point endPoint)
        {
            return startPoint.X != endPoint.X ? Orientation.Vertical : Orientation.Horizontal;
        }
    }


}
