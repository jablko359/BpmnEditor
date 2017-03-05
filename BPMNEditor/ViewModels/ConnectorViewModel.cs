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
        private BaseElementViewModel _parentViewModel;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyOfPropertyChange(nameof(Position));
            }
        }

        public ConnectorViewModel(BaseElementViewModel baseElementViewModel)
        {
            _parentViewModel = baseElementViewModel;
        }

        public void ConnectorStart()
        {
            _parentViewModel.ConnectorStart();
        }

    }
}
