using System.Windows;

namespace BPMNCore.ViewModels
{
    public abstract class ConnectorBase : PropertyChangedBase
    {
        private Point _position;

        public Point Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                {
                    return;
                }
                //Console.WriteLine("Set position to {0}, placement {1}", value, Placemement);
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
