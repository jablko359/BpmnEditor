using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BPMNCore;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public abstract class BaseConnectionViewModel : BaseElementViewModel
    {
        private Point _startPoint;
        private Point _endPoint;
        private PointCollection _points;
       
        protected ConnectorViewModel _start;

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

        #endregion

        private readonly HashSet<Type> _applicableSet = new HashSet<Type>();

        protected BaseConnectionViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
        }

        public abstract void CalculatePath();

        protected int GetArrowIndex(List<Point> points, Placemement end)
        {
            int index = points.Count;
            for (int i = points.Count - 1; i > 0; i--)
            {
                if (end == Placemement.Bottom || end == Placemement.Top)
                {
                    if (points[i].X == EndPoint.X)
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
                    if (points[i].Y == EndPoint.Y)
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





        #region BaseElementViewModel

        public override bool IsSelectableByUser => false;
        protected override HashSet<Type> ApplicableTypes => _applicableSet;
        protected override VisualElement CreateElement()
        {
            return null;
        }

        #endregion




    }


}
