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
    public class LaneViewModel : VisualElementViewModel, IInsertable
    {
        public const double MinHeight = 75;
        
        private readonly PoolViewModel _pool;

        public LaneViewModel Next { get; set; }

        #region Properties

        public LaneElement Lane { get; }
        public int Index { get; private set; }

        public string Name
        {
            get { return Lane.Name; }
            set
            {
                Lane.Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public ICommand DeleteCommand { get; }

        #endregion



        public LaneViewModel(int index, PoolViewModel poolViewModel)
        {
            Index = index;
            Lane = new LaneElement()
            {
                Height = 150
            };
            BaseElement = Lane;
            DeleteCommand = new RelayCommand(x => Delete());
            _pool = poolViewModel;
        }

        public LaneViewModel(int index, PoolViewModel poolViewModel, LaneElement lane) : this(index,poolViewModel)
        {
            Lane = lane;
            BaseElement = lane;
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
