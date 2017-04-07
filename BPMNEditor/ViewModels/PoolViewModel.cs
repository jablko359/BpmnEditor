using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.Tools.GraphTools;

namespace BPMNEditor.ViewModels
{
    public class PoolViewModel : BaseElementViewModel, IDropable, IContentSelectable
    {
        public const double InitialWidth = 700;
        public const double InitialHeight = 350;

        #region Private members

        private Pool _pool;
        private string _name;
        private bool _isDragOver;
        private readonly List<PoolElementViewModel> _elements = new List<PoolElementViewModel>();

        #endregion

        #region Properties

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

        public IReadOnlyList<PoolElementViewModel> Elements => _elements;

        #endregion

        #region Contructor

        public PoolViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>();
            LocationChanged += PoolViewModel_LocationChanged;
            _name = "Pool";
        }

        

        #endregion

        #region BaseElementViewModel

        protected override HashSet<Type> ApplicableTypes { get; }
        protected override IBaseElement CreateElement()
        {
            _pool = new Pool();
            return _pool;
        }

        #endregion

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
            if (index > 0)
            {
                LaneViewModel previousLane = Lanes[index - 1];
                previousLane.Next = laneViewModel;
            }

            PropertyChanged += laneViewModel.PoolPropertyChanged;
            foreach (LaneViewModel lane in Lanes)
            {
                PropertyChanged -= lane.PoolPropertyChanged;
            }
            MinHeight = CalculateMinHeight();
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

        private double CalculateMinHeight()
        {
            return (Lanes.Count + 1) * LaneViewModel.MinHeight;
        }

        public bool CanSelect { get { return !IsSelected; } }

        public void RemoveElement(PoolElementViewModel poolElementViewModel)
        {
            _elements.Remove(poolElementViewModel);
        }

        public void AddElement(PoolElementViewModel poolElementViewModel)
        {
            _elements.Add(poolElementViewModel);
        }

        private void PoolViewModel_LocationChanged(object sender, Tools.LocationChagnedEventArgs e)
        {
            var tempElements = new List<PoolElementViewModel>(_elements);
            foreach (PoolElementViewModel element in tempElements)
            {
                element.Left += e.HorizontalChange;
                element.Top += e.VerticalChange;
            }
        }

        protected override void DimensionChanged()
        {
            var poolRect = Helper.GetRect(this);
            foreach (BaseElementViewModel baseElement in Document.BaseElements)
            {
                PoolElementViewModel poolElementViewModel = baseElement as PoolElementViewModel;
                if (poolElementViewModel != null)
                {
                    var objectRect = Helper.GetRect(baseElement);
                    if (poolRect.Contains(objectRect))
                    {
                        if (poolElementViewModel.Pool != null)
                        {
                            continue;
                        }
                        AddElement(poolElementViewModel);
                        poolElementViewModel.Pool = this;
                    }
                }
            }
        }

        public override void StartMove()
        {
            base.StartMove();
        }

        public override void StopMove()
        {
            base.StopMove();
        }
    }
}
