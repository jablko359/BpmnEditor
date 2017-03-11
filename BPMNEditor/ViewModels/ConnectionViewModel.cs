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
        #endregion


        private HashSet<Type> _applicableSet = new HashSet<Type>();

        public ConnectionViewModel(DocumentViewModel documentViewModel, ConnectorViewModel start, ConnectorViewModel end) : base(documentViewModel)
        {
            StartPoint = start.Position;
            EndPoint = end.Position;
            start.PropertyChanged += Start_PropertyChanged;
            end.PropertyChanged += End_PropertyChanged;
        }

        private void End_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel end = sender as ConnectorViewModel;
            if (end != null && e.PropertyName == "Position")
            {
                EndPoint = end.Position;
            }
        }

        private void Start_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ConnectorViewModel start = sender as ConnectorViewModel;
            if (start != null && e.PropertyName == "Position")
            {
                StartPoint = start.Position;
            }
        }

        protected override HashSet<Type> ApplicableTypes { get { return _applicableSet; } }
        protected override IBaseElement CreateElement()
        {
            return null;
        }
    }
}
