using System;

namespace BPMNCore
{
    public class LocationChagnedEventArgs : EventArgs
    {
        public double VerticalChange { get; private set; }
        public double HorizontalChange { get; private set; }

        public LocationChagnedEventArgs(double verticalChange, double horizontalChange)
        {
            VerticalChange = verticalChange;
            HorizontalChange = horizontalChange;
        }
    }
}
