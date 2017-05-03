using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public abstract class VisualElementViewModel : PropertyChangedBase
    {
        private double _width;
        private double _height;
        private double _left;
        private double _top;


        public event EventHandler<LocationChagnedEventArgs> LocationChanged;

        [Browsable(false)]
        public IBaseElement BaseElement { get; protected set; }

        [Category(Categories.LayoutCategory)]
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                UpdateModelPosition();
                NotifyOfPropertyChange(nameof(Width));
            }
        }

        [Category(Categories.LayoutCategory)]
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                UpdateModelPosition();
                NotifyOfPropertyChange(nameof(Height));
            }
        }

        [Category(Categories.LayoutCategory)]
        public double Left
        {
            get { return _left; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(0, value - Left);
                    _left = value;
                    UpdateModelPosition();
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Left));
                }

            }
        }

        [Category(Categories.LayoutCategory)]
        public double Top
        {
            get { return _top; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(value - Top, 0);
                    _top = value;
                    UpdateModelPosition();
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Top));
                }

            }
        }

        protected void UpdateModelPosition()
        {
            VisualElement visualElement = BaseElement as VisualElement;
            if (visualElement != null)
            {
                visualElement.Y = Top;
                visualElement.X = Left;
                visualElement.Height = Height;
                visualElement.Width = Width;
            }
        }

        private void NotifyLocationChanged(LocationChagnedEventArgs args)
        {
            LocationChanged?.Invoke(this, args);
        }
    }
}
