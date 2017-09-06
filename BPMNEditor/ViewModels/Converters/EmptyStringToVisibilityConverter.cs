using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class EmptyStringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;
            Visibility result = Visibility.Collapsed;
            if (!string.IsNullOrEmpty(stringValue))
            {
                result = Visibility.Visible;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
