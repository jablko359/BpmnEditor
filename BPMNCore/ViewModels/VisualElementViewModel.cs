using System;
using System.ComponentModel;

namespace BPMNCore.ViewModels
{
    public abstract class VisualElementViewModel : PropertyChangedBase
    {
        public event EventHandler<LocationChagnedEventArgs> LocationChanged;

        [Browsable(false)]
        public VisualElement BaseElement { get; protected set; }

        [Category(Categories.LayoutCategory)]
        public double Width
        {
            get { return BaseElement.Width; }
            set
            {
                BaseElement.Width = value;
                NotifyOfPropertyChange(nameof(Width));
            }
        }

        [Category(Categories.LayoutCategory)]
        public double Height
        {
            get { return BaseElement.Height; }
            set
            {
                BaseElement.Height = value;
        
                NotifyOfPropertyChange(nameof(Height));
            }
       } 

        [Category(Categories.LayoutCategory)]
        public double Left
        {
            get { return BaseElement.X; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(0, value - Left);
                    BaseElement.X = value;
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Left));
                }

            }
        }

        [Category(Categories.LayoutCategory)]
        public double Top
        {
            get { return BaseElement.Y; }
            set
            {
                if (value > 0)
                {
                    LocationChagnedEventArgs args = new LocationChagnedEventArgs(value - Top, 0);
                    BaseElement.Y = value;
                    NotifyLocationChanged(args);
                    NotifyOfPropertyChange(nameof(Top));
                }

            }
        }

        

        private void NotifyLocationChanged(LocationChagnedEventArgs args)
        {
            LocationChanged?.Invoke(this, args);
        }
    }
}
