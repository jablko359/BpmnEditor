using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BPMNCore;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public class ElementsConnectionViewModel : BaseConnectionViewModel
    {
        private List<Hook> _hooks;


        private readonly ConnectorViewModel _end;
        private bool _isContextMenuOpened;

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

        public ConnectionElement Model { get; }

        public BaseElementViewModel From { get; private set; }
        public BaseElementViewModel To { get; private set; }

        /// <summary>
        /// Creates ElementsConnectionViewModel and add model connection
        /// </summary>
        /// <param name="documentViewModel"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public ElementsConnectionViewModel(DocumentViewModel documentViewModel, ConnectorViewModel start, ConnectorViewModel end) : base(documentViewModel)
        {
            BaseElement = new VisualElement();
            _start = start;
            _end = end;
            StartPoint = start.Position;
            EndPoint = end.Position;
            From = start.Parent;
            To = end.Parent;
            start.PropertyChanged += Start_PropertyChanged;
            end.PropertyChanged += End_PropertyChanged;
            start.Parent.ElementDeleted += ElementDeleted;
            end.Parent.ElementDeleted += ElementDeleted;
            start.Parent.SetConnection(this);
            end.Parent.SetConnection(this);
            Hooks = new List<Hook>();
            Model = new ConnectionElement(start.Parent.BaseElement, end.Parent.BaseElement);
            ModelHelper.AddModelConnection(this);
            CalculatePath();
        }

        public ElementsConnectionViewModel(DocumentViewModel documentViewModel, ConnectionElement model, BaseElementViewModel start, BaseElementViewModel end, Point startPoint, Point endPoint) : base(documentViewModel)
        {
            BaseElement = new VisualElement();
            var startConenctor = start.GetNearestConnector(startPoint);
            var endConnector = end.GetNearestConnector(endPoint);
            _start = startConenctor;
            _end = endConnector;
            StartPoint = startConenctor.Position;
            EndPoint = endConnector.Position;
            From = startConenctor.Parent;
            To = endConnector.Parent;
            startConenctor.PropertyChanged += Start_PropertyChanged;
            endConnector.PropertyChanged += End_PropertyChanged;
            startConenctor.Parent.ElementDeleted += ElementDeleted;
            endConnector.Parent.ElementDeleted += ElementDeleted;
            startConenctor.Parent.SetConnection(this);
            endConnector.Parent.SetConnection(this);
            Hooks = new List<Hook>();
            Model = model;
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

        public override void CalculatePath()
        {
            List<Point> points = PathCreator.GetConnectionLine(_start, _end, true);// _pathFinder.CalculatePath(StartPoint, EndPoint, _startPlacement, _endPlacemement, Hooks.Where(item => item.IsMoved).ToList());
            int idx = GetArrowIndex(points, _end.Placemement);
            ArrowPoint = points[idx];
            CalculateHooks(points);
            points.Insert(0, StartPoint);
            Points = new PointCollection(points.GetRange(0, idx + 2));
            Model.Points = new List<Point>() {StartPoint, EndPoint};
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
                            temPoints[i] = new Point(hook.HookPoint.X, toChangePoint.Y);
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
            List<Point> points = new List<Point>(Points) { ArrowPoint };
            CalculateHooks(points);
        }
    }
}
