﻿using System;
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


        private readonly Placemement _startPlacement;
        private readonly Placemement _endPlacemement;

        #region Properties

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


        #endregion


        private readonly HashSet<Type> _applicableSet = new HashSet<Type>();

        public ConnectionViewModel(DocumentViewModel documentViewModel, ConnectorViewModel start, ConnectorViewModel end) : base(documentViewModel)
        {
            StartPoint = start.Position;
            EndPoint = end.Position;
            start.PropertyChanged += Start_PropertyChanged;
            end.PropertyChanged += End_PropertyChanged;
            _startPlacement = start.Placemement;
            _endPlacemement = end.Placemement;
            CalculateBreakPoint();
        }

        private void End_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel end = sender as ConnectorViewModel;
            if (end != null && e.PropertyName == "Position")
            {
                if (!EndPoint.Equals(end.Position))
                {
                    EndPoint = end.Position;
                    CalculateBreakPoint();
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
                    CalculateBreakPoint();
                }

            }
        }

        private void CalculateBreakPoint()
        {
            IEnumerable<Point> points = Document.PathFinder.CalculatePath(StartPoint, EndPoint, _startPlacement, _endPlacemement);
            Points = new PointCollection(points);
            CalculateHooks(Points);
        }

        private void CalculateHooks(PointCollection points)
        {
            List<Hook> hooks = new List<Hook>();
            for (int i = 1; i < points.Count; i++)
            {
                Point startPoint = points[i - 1];
                Point endPoint = points[i];
                double x = (startPoint.X + endPoint.X) / 2;
                double y = (startPoint.Y + endPoint.Y) / 2;
                //prevent adding hooks 
                if (x != EndPoint.X && y != EndPoint.Y)
                {
                    Point hookPoint = new Point(x, y);
                    Orientation hookOrientation = Hook.GetOrientation(startPoint, endPoint);
                    hooks.Add(new Hook(hookPoint, hookOrientation));
                }

            }
            Hooks = hooks;
        }

        #region BaseElementViewModel

        protected override HashSet<Type> ApplicableTypes { get { return _applicableSet; } }
        protected override IBaseElement CreateElement()
        {
            return null;
        }

        #endregion




    }


}
