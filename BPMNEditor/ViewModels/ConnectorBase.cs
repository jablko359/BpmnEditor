using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BPMNEditor.ViewModels
{
    public abstract class ConnectorBase : PropertyChangedBase
    {
        private Point _position;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyOfPropertyChange(nameof(Position));
            }
        }

        public Placemement Placemement
        {
            get; protected set;
        }

        protected ConnectorBase()
        {
        }

        protected ConnectorBase(Placemement placemement)
        {
            Placemement = placemement;
        }

        public abstract Rect GetParentRectWithMargin(double margin);
    }
}
