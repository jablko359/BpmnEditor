using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.DragAndDrop;

namespace BPMNEditor.ViewModels
{
    public class PoolViewModel : BaseElementViewModel, IDropable
    {
        public const double InitialWidth = 700;
        public const double InitialHeight = 350;

        private Pool _pool;

        private string _name;

        private bool _isDragOver;

        public ObservableCollection<LaneViewModel> Lanes { get; } = new ObservableCollection<LaneViewModel>();


        public bool IsDragOver
        {
            get { return _isDragOver; }
            set
            {
                _isDragOver = value;
                NotifyOfPropertyChange(nameof(IsDragOver));
            }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }


        public PoolViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>();
            _name = "Pool";
        }


        protected override HashSet<Type> ApplicableTypes { get; }
        protected override IBaseElement CreateElement()
        {
            _pool = new Pool();
            return _pool;
        }

        #region IDropable

        public Type DataType => typeof(IPoolElement);

        public void Drop(object data, double x = 0, double y = 0)
        {
            IsDragOver = false;
            ITypeProvider provider = data as ITypeProvider;
            if (provider != null && provider.ElementType == typeof(Lane))
            {
                AddNewLane();
            }
        }

        public void DragOver(double x, double y, object dragItem)
        {
            IsDragOver = true;
        }

        public void DragLeave()
        {
            IsDragOver = false;
        }

        #endregion

        private void AddNewLane()
        {
            int index = Lanes.Count;
            LaneViewModel laneViewModel = new LaneViewModel(index, this);
            PropertyChanged += laneViewModel.PoolPropertyChanged;
            foreach (LaneViewModel lane in Lanes)
            {
                PropertyChanged -= lane.PoolPropertyChanged;
            }
            MinHeight = CalculateMinHeight(laneViewModel);
            if (index == 0)
            {
                laneViewModel.Height = Height;
            }
            else
            {
                Height += laneViewModel.Height;
            }
            Lanes.Add(laneViewModel);
        }

        private double CalculateMinHeight(LaneViewModel addedLane)
        {
            return Lanes.Sum(item => item.Height) + LaneViewModel.MinHeight;
        }

    }
}
