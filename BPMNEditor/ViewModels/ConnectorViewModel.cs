using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BPMNEditor.ViewModels
{
    public class ConnectorViewModel : PropertyChangedBase
    {
        private Point _position;
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
            get; 
        }

        public BaseElementViewModel Parent
        {
            get { return _parentViewModel; }
        }

        public ConnectorViewModel(BaseElementViewModel baseElementViewModel, Placemement placemement)
        {
            _parentViewModel = baseElementViewModel;
            Placemement = placemement;
            baseElementViewModel.AddConenctor(this);
        }

        public void ConnectorStart()
        {
            _parentViewModel.ConnectorStart(this);
        }

    }

    public enum Placemement
    {
        Left, Top, Right, Bottom
    }
}
