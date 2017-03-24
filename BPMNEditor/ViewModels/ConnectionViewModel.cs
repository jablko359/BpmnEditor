using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public class ConnectionViewModel : BaseElementViewModel
    {
        private Point _startPoint;
        private Point _endPoint;
        private PointCollection _points;
        private List<Hook> _hooks;
        private bool _isContextMenuOpened;
        private ConnectorViewModel _start;
        private ConnectorViewModel _end;

        private readonly Placemement _startPlacement;
        private readonly Placemement _endPlacemement;

        #region Properties

        private Point _arrowPoint;

        public Point ArrowPoint
        {
            get { return _arrowPoint; }
            set
            {
                _arrowPoint = value;
                NotifyOfPropertyChange(nameof(ArrowPoint));
            }
        }


        public Point StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
                NotifyOfPropertyChange(nameof(StartPoint));
            }
        }
        public Point EndPoint
        {
            get { return _endPoint; }
            set
            {

                _endPoint = value;
                NotifyOfPropertyChange(nameof(EndPoint));
            }
        }

        public PointCollection Points
        {
            get { return _points; }
            set
            {
                _points = value;
                NotifyOfPropertyChange(nameof(Points));
            }

        }



        public List<Hook> Hooks
        {
            get { return _hooks; }
            set
            {
                _hooks = value;
                NotifyOfPropertyChange(nameof(Hooks));
            }
        }



        public bool IsContextMenuOpened
        {
            get { return _isContextMenuOpened; }
            set
            {
                _isContextMenuOpened = value;
                NotifyOfPropertyChange(nameof(IsContextMenuOpened));
            }
        }





        #endregion


        private readonly HashSet<Type> _applicableSet = new HashSet<Type>();

        public ConnectionViewModel(DocumentViewModel documentViewModel, ConnectorViewModel start, ConnectorViewModel end) : base(documentViewModel)
        {
            _start = start;
            _end = end;
            StartPoint = start.Position;
            EndPoint = end.Position;
            start.PropertyChanged += Start_PropertyChanged;
            end.PropertyChanged += End_PropertyChanged;
            start.Parent.ElementDeleted += ElementDeleted;
            end.Parent.ElementDeleted += ElementDeleted;
            start.Parent.SetConnection(this);
            end.Parent.SetConnection(this);
            _startPlacement = start.Placemement;
            _endPlacemement = end.Placemement;
            Hooks = new List<Hook>();
            CalculatePath();
        }

        private void ElementDeleted(object sender, EventArgs e)
        {
            DeleteCommand.Execute(null);
        }

        private void End_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel end = sender as ConnectorViewModel;
            if (end != null && e.PropertyName == "Position")
            {
                if (!EndPoint.Equals(end.Position))
                {
                    EndPoint = end.Position;
                    CalculatePath();
                }
            }
        }

        private void Start_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel start = sender as ConnectorViewModel;
            if (start != null && e.PropertyName == "Position")
            {
                if (!StartPoint.Equals(start.Position))
                {
                    StartPoint = start.Position;
                    CalculatePath();
                }

            }
        }

        private void CalculatePath()
        {
            List<Point> points = PathCreator.GetConnectionLine(_start, _end, true);// _pathFinder.CalculatePath(StartPoint, EndPoint, _startPlacement, _endPlacemement, Hooks.Where(item => item.IsMoved).ToList());
            int idx = GetArrowIndex(points);
            ArrowPoint = points[idx];
            CalculateHooks(points);
            Points = new PointCollection(points.Take(idx + 1));

        }

        private int GetArrowIndex(List<Point> points)
        {
            int index = points.Count;
            for (int i = points.Count - 1; i > 0; i--)
            {
                if (_end.Placemement == Placemement.Bottom || _end.Placemement == Placemement.Top)
                {
                    if (points[i].X == _endPoint.X)
                    {
                        index = i;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (points[i].Y == _endPoint.Y)
                    {
                        index = i;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return index;
        }

        private void CalculateHooks(List<Point> points)
        {
            List<Hook> hooks = new List<Hook>();
            Point? lastCornerPoint = null;
            for (int i = 2; i < points.Count; i++)
            {
                Point point1 = points[i - 2];
                Point point2 = points[i - 1];
                Point point3 = points[i];
                if (point1.X != point3.X && point1.Y != point3.Y)
                {
                    if (lastCornerPoint != null)
                    {
                        var hook = new Hook(lastCornerPoint.Value, point2, this);
                        hooks.Add(hook);
                    }
                    lastCornerPoint = point2;
                }
                //Point startPoint = points[i - 1];
                //Point endPoint = points[i];
                //double x = (startPoint.X + endPoint.X) / 2;
                //double y = (startPoint.Y + endPoint.Y) / 2;
                ////prevent adding hooks 
                //if (x != EndPoint.X && y != EndPoint.Y)
                //{
                //    Hook newHook = new Hook(startPoint, endPoint, this);
                //    hooks.Add(newHook);
                //    Hook oldHook = userHooks.FirstOrDefault(
                //        item => item.StartPoint.Equals(newHook.StartPoint) || item.EndPoint.Equals(newHook.EndPoint));
                //    if (oldHook != null && oldHook.Orientation == newHook.Orientation)
                //    {
                //        newHook.IsMoved = true;
                //    }
                //}

            }
            Hooks = hooks;
        }

        public void HookChange(Hook hook)
        {
            foreach (Hook hookToNotify in Hooks)
            {
                if (hookToNotify != hook)
                {
                    hookToNotify.IsVisible = false;
                }
            }
            PointCollection temPoints = new PointCollection(Points);
            int startIndex = temPoints.IndexOf(hook.OriginalStartPoint);
            int endIndex = temPoints.IndexOf(hook.OriginalEndPoint);
            if (startIndex != -1 && endIndex != -1)
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Point toChangePoint = temPoints[i];
                    
                    switch (hook.Orientation)
                    {
                        case Orientation.Horizontal:
                            temPoints[i] = new Point(hook.HookPoint.X,toChangePoint.Y);
                             break;
                        case Orientation.Vertical:
                            temPoints[i] = new Point(toChangePoint.X, hook.HookPoint.Y);
                            break;
                    }
                }
                hook.SetNewPoints();
            }
            Points = temPoints;
            ArrowPoint = Points[Points.Count - 1];
        }

        public void RecalculateHooks()
        {
            List<Point> points = new List<Point>(Points) {ArrowPoint};
            CalculateHooks(points);
        }

        #region BaseElementViewModel

        public override bool IsSelectableByUser => false;
        protected override HashSet<Type> ApplicableTypes => _applicableSet;
        protected override IBaseElement CreateElement()
        {
            return null;
        }

        #endregion




    }


}
