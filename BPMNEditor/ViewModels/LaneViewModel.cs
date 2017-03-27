using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;

namespace BPMNEditor.ViewModels
{
    public class LaneViewModel : PropertyChangedBase
    {
        public const double MinHeight = 75;

        public Lane Lane { get;  }
        public int Index { get; private set; }

        private double _height;
        private string _name;
        private readonly PoolViewModel _pool;
        public event EventHandler<HeightChangedEventArgs> HeightChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }


        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyOfPropertyChange(nameof(Height));
            }
        }


        public LaneViewModel(int index, PoolViewModel poolViewModel)
        {
            Index = index;
            _name = "Lane";
            Height = 150;
            Lane = new Lane();
            _pool = poolViewModel;
        }

        public void PoolPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Height")
            {
                double lanesHeight = _pool.Lanes.Where(lane => lane != this).Sum(lane => lane.Height);
                double desiredHeight = _pool.Height - lanesHeight;
                Height = desiredHeight;
            }
        }

        

        public void Resize(double newHeight)
        {
            if (newHeight > MinHeight)
            {
                HeightChanged?.Invoke(this, new HeightChangedEventArgs(Height, newHeight));
                Height = newHeight;
            }
            
        }

        public void PreviousLaneHeightChanged(object sender, HeightChangedEventArgs e)
        {
            var difference = e.PreviousValue - e.NewValue;
            Height += difference;
        }

        public class HeightChangedEventArgs : EventArgs
        {
            public double PreviousValue { get; }
            public double NewValue { get; }

            public HeightChangedEventArgs(double previousValue, double newValue)
            {
                PreviousValue = previousValue;
                NewValue = newValue;
            }
        }
        
    }
}
