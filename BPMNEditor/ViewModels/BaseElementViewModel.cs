using System;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;


namespace BPMNEditor.ViewModels
{
    public abstract class BaseElementViewModel : PropertyChangedBase
    {
        private double _width;
        private double _top;
        private double _height;
        private double _left;

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
                _left = value;
                NotifyOfPropertyChange(nameof(Left));
            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                NotifyOfPropertyChange(nameof(Top));
            }
        }

        public IBaseElement BaseElement { get; private set; }

        protected abstract IBaseElement CreateElement();


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
