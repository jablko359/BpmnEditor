using System;
using System.Windows.Input;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;
using BPMNEditor.Tools.DragAndDrop;
using BPMNEditor.ViewModels.Command;


namespace BPMNEditor.ViewModels
{
    public abstract class BaseElementViewModel : PropertyChangedBase, IResizableObject
    {
        private double _width;
        private double _top;
        private double _height;
        private double _left;
        private bool _isSelected;

        public ICommand SelectCommand { get; private set; }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(nameof(Width));
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

        public double Left
        {
            get { return _left; }
            set
            {
                if (value > 0)
                {
                    _left = value;
                    NotifyOfPropertyChange(nameof(Left));
                }
                
            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                if (value > 0)
                {
                    _top = value;
                    NotifyOfPropertyChange(nameof(Top));
                }
                
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(nameof(IsSelected));
            }
        }


        public double MinHeight { get; set; }
        public double MinWidth { get; set; }

        public IBaseElement BaseElement { get; private set; }

        protected abstract IBaseElement CreateElement();

        public event EventHandler<EventArgs> ItemSelectedEvent;

        protected BaseElementViewModel()
        {
            SelectCommand = new RelayCommand(item => Select());
        }

        public void Select()
        {
            IsSelected = true;
            ItemSelectedEvent?.Invoke(this, new EventArgs());
        }

        public void Deselect()
        {
            IsSelected = false;
        }

        public static BaseElementViewModel GetViewModel(Type elementType)
        {
            ElementViewModelAttribute attribute =
                (ElementViewModelAttribute)Attribute.GetCustomAttribute(elementType, typeof(ElementViewModelAttribute));
            if (attribute == null)
            {
                throw new NotSupportedException(string.Format("Not supported type {0}. Does not have ElementViewModelAttribute", elementType));
            }
            Type viewModelType = attribute.ViewModelType;
            BaseElementViewModel viewModel =
                (BaseElementViewModel)Activator.CreateInstance(viewModelType);
            viewModel.BaseElement = viewModel.CreateElement();
            viewModel.Height = attribute.InitialSize.Height;
            viewModel.Width = attribute.InitialSize.Width;
            return viewModel;
        }
    }
}
