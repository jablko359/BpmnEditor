using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNCore;
using BPMNEditor.Models.Elements;
using BPMNEditor.Tools;

namespace BPMNEditor.ViewModels
{
    public abstract class VisualElementViewModel : PropertyChangedBase
    {
        public event EventHandler<LocationChagnedEventArgs> LocationChanged;

        [Browsable(false)]
        public VisualElement BaseElement { get; protected set; }

        [Browsable(false)]
        public double Width
        {
            get { return BaseElement.Width; }
            set
            {
                if (value > 0)
                {
                    BaseElement.Width = value;
                    NotifyOfPropertyChange(nameof(Width));
                }
                
            }
        }

        [Browsable(false)]
        public double Height
        {
            get { return BaseElement.Height; }
            set
            {
                if (value > 0)
                {
                    BaseElement.Height = value;
                    NotifyOfPropertyChange(nameof(Height));
                }
                
            }
       }

        [Browsable(false)]
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

        [Browsable(false)]
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
