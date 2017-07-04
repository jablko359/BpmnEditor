using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class PlacementToHorizontalAligmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Placemement placemement = (Placemement) value;
            HorizontalAlignment result = HorizontalAlignment.Center;
            if (placemement == Placemement.Left)
            {
                result = HorizontalAlignment.Left;
            }
            else if (placemement == Placemement.Right)
            {
                result = HorizontalAlignment.Right;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}