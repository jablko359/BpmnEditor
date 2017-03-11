using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.ViewModels
{
    public class ConnectionViewModel : BaseElementViewModel
    {
        private Point _startPoint;
        private Point _endPoint;
        private Point _firtsBreakPoint;
        private Point _secondBreakPoint;
        private ConnectionType _type;

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

        public Point FirtsBreakPoint
        {
            get { return _firtsBreakPoint; }
            set
            {
                _firtsBreakPoint = value;
                NotifyOfPropertyChange(nameof(FirtsBreakPoint));
            }
        }

        public Point SecondBreakPoint
        {
            get { return _secondBreakPoint; }
            set
            {
                _secondBreakPoint = value;
                NotifyOfPropertyChange(nameof(SecondBreakPoint));
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
            _type = GetConnectionType(start.Placemement, end.Placemement);
        }

        private void End_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel end = sender as ConnectorViewModel;
            if (end != null && e.PropertyName == "Position")
            {
                EndPoint = end.Position;
                CalculateBreakPoint();
            }
        }

        private void Start_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel start = sender as ConnectorViewModel;
            if (start != null && e.PropertyName == "Position")
            {
                StartPoint = start.Position;
                CalculateBreakPoint();
            }
        }

        protected override HashSet<Type> ApplicableTypes { get { return _applicableSet; } }
        protected override IBaseElement CreateElement()
        {
            return null;
        }

        public void CalculateBreakPoint()
        {
            double horizontalBreak = (StartPoint.X + EndPoint.X) / 2;
            double verticalBreak = (StartPoint.Y + EndPoint.Y) / 2;
            switch (_type)
            {
                case ConnectionType.Horizontal:
                    _firtsBreakPoint.X = horizontalBreak;
                    _firtsBreakPoint.Y = StartPoint.Y;
                    _secondBreakPoint.X = horizontalBreak;
                    _secondBreakPoint.Y = EndPoint.Y;
                    break;
                case ConnectionType.Vertical:
                    _firtsBreakPoint.X = StartPoint.X;
                    _firtsBreakPoint.Y = verticalBreak;
                    _secondBreakPoint.X = EndPoint.X;
                    _secondBreakPoint.Y = verticalBreak;
                    break;
                case ConnectionType.Mixed:
                    _firtsBreakPoint.X = StartPoint.X;
                    _firtsBreakPoint.Y = StartPoint.Y;
                    _secondBreakPoint.X = StartPoint.X;
                    _secondBreakPoint.Y = EndPoint.Y;
                    break;
            }
            NotifyOfPropertyChange(nameof(FirtsBreakPoint));
            NotifyOfPropertyChange(nameof(SecondBreakPoint));
        }

        private static ConnectionType GetConnectionType(Placemement startPlacemement, Placemement endPlacemement)
        {
            ConnectionType result = ConnectionType.Horizontal;
            if (GetPlacementSubType(startPlacemement) != GetPlacementSubType(endPlacemement))
            {
                result = ConnectionType.Mixed;
            }
            else if (startPlacemement == Placemement.Left || startPlacemement == Placemement.Right)
            {
                result = ConnectionType.Horizontal;
            }
            else
            {
                result = ConnectionType.Vertical;
            }
            return result;
        }

        private static ConnectionType GetPlacementSubType(Placemement placement)
        {
            return (placement == Placemement.Left || placement == Placemement.Right) ? ConnectionType.Horizontal : ConnectionType.Vertical;
        }

        private enum ConnectionType
        {
            Horizontal, Vertical, Mixed
        }
    }
}
