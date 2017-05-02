using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.ViewModels.Command;
using Lane = BPMNEditor.Xpdl.Lane;

namespace BPMNEditor.ViewModels
{
    public class LaneViewModel : PropertyChangedBase, IInsertable
    {
        public const double MinHeight = 75;



        private double _height;
        private string _name;
        private readonly PoolViewModel _pool;

        public LaneViewModel Next { get; set; }

        #region Properties

        public Lane Lane { get; }
        public int Index { get; private set; }

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

        public ICommand DeleteCommand { get; }

        #endregion



        public LaneViewModel(int index, PoolViewModel poolViewModel)
        {
            Index = index;
            _name = "Lane";
            Height = 150;
            Lane = new Lane();
            DeleteCommand = new RelayCommand(x => Delete());
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
                //HeightChanged?.Invoke(this, new HeightChangedEventArgs(Height, newHeight));
                var difference = Height - newHeight;
                double newNextHeight = Next.Height + difference;
                if (newNextHeight > MinHeight)
                {
                    Height = newHeight;
                    Next.Height += difference;
                }
            }

        }

        public void Delete()
        {
            _pool.DeleteLine(this);
        }

        public void PreviousLaneHeightChanged(object sender, HeightChangedEventArgs e)
        {
            var difference = e.PreviousValue - e.NewValue;
            Height += difference;
        }

        public void AfterInsert()
        {
            
        }

        public void AfterDelete()
        {
            
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
