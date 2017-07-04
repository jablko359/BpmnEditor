using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class PlacementToVerticalAligmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Placemement placemement = (Placemement)value;
            VerticalAlignment result = VerticalAlignment.Center;
            if (placemement == Placemement.Top)
            {
                result = VerticalAlignment.Top;
            }
            else if (placemement == Placemement.Bottom)
            {
                result = VerticalAlignment.Bottom;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}