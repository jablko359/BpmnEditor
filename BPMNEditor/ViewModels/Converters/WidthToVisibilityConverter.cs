using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class WidthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringParameter = (string)parameter;
            double minWidth;
            if (Double.TryParse(stringParameter, out minWidth))
            {
                double actualWidth = (double)value;
                Visibility result = Visibility.Visible;
                if (actualWidth < minWidth)
                {
                    result = Visibility.Collapsed;
                }
                return result;
            }
            else
            {
                throw new ArgumentException("Incorrect argument in WidthToVisibilityConverter");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}