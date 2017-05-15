using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BPMNEditor.Actions;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.Tools.GraphTools;
using BPMNEditor.ViewModels.Command;

namespace BPMNEditor.ViewModels
{
    public class PoolViewModel : BaseElementViewModel, IDropable, IContentSelectable, IElementsContainer<LaneViewModel>
    {
        public const double InitialWidth = 700;
        public const double InitialHeight = 350;

        #region Private members

        private PoolElement _poolElement;
        private bool _isDragOver;
        private readonly HashSet<PoolElementViewModel> _elements = new HashSet<PoolElementViewModel>();

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
            get { return _poolElement.Name; }
            set
            {
                _poolElement.Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public HashSet<PoolElementViewModel> Elements => _elements;

        #endregion

        #region Contructor

        public PoolViewModel(DocumentViewModel documentViewModel) : base(documentViewModel)
        {
            ApplicableTypes = new HashSet<Type>();
            LocationChanged += PoolViewModel_LocationChanged;

        }

        public PoolViewModel(DocumentViewModel documentViewModel, PoolElement poolElement) : this(documentViewModel)
        {
            _poolElement = poolElement;
            BaseElement = _poolElement;
            int count = 0;
            foreach (LaneElement lane in poolElement.Lanes)
            {
                LaneViewModel laneViewModel = new LaneViewModel(count, this, lane);
                if (count == poolElement.Lanes.Count - 1)
                {
                    PropertyChanged += laneViewModel.PoolPropertyChanged;
                }
                Lanes.Add(laneViewModel);
                count++;
            }
            MinHeight = CalculateMinHeight();
        }

        #endregion

        #region BaseElementViewModel

        protected override HashSet<Type> ApplicableTypes { get; }
        protected override VisualElement CreateElement()
        {
            _poolElement = new PoolElement();
            Name = "Pool";
            return _poolElement;
        }

        #endregion

        #region IDropable

        public Type DataType => typeof(IPoolElement);

        public void Drop(object data, double x = 0, double y = 0)
        {
            IsDragOver = false;
            ITypeProvider provider = data as ITypeProvider;
            if (provider != null && provider.ElementType == typeof(LaneElement))
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

        public void DeleteLine(LaneViewModel lane)
        {
            var index = Lanes.IndexOf(lane);

            if (index == Lanes.Count - 1)
            {
                if (index > 0)
                {
                    LaneViewModel previousLane = Lanes[index - 1];

                    PropertyChanged -= lane.PoolPropertyChanged;
                    PropertyChanged += previousLane.PoolPropertyChanged;
                }
            }
            else if (index > 0)
            {
                LaneViewModel next = lane.Next;
                LaneViewModel previousLane = Lanes[index - 1];
                previousLane.Next = next;
            }
            Lanes.Remove(lane);
            _poolElement.Lanes.Remove(lane.Lane);
            NotifyOfPropertyChange(nameof(Height));

            NotifyActionPerformed(new GenericDeletedAction<LaneViewModel>(this, lane));
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
            _poolElement.Lanes.Add(laneViewModel.Lane);
            GenericAddedAction<LaneViewModel> laneAddedAction = new GenericAddedAction<LaneViewModel>(this, laneViewModel);
            NotifyActionPerformed(laneAddedAction);
        }

        private double CalculateMinHeight()
        {
            return (Lanes.Count + 1) * LaneViewModel.MinHeight;
        }

        public bool CanSelect { get { return !IsSelected; } }

        public void RemoveElement(PoolElementViewModel poolElementViewModel)
        {
            _poolElement.Elements.Remove(poolElementViewModel.BaseElement);

            _elements.Remove(poolElementViewModel);
        }

        public void AddElement(PoolElementViewModel poolElementViewModel)
        {
            _poolElement.Elements.Add(poolElementViewModel.BaseElement);
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

        public IList<LaneViewModel> Items => Lanes;

    }
}
