using System;
using System.Globalization;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class IsCollectionEmpty : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int size = (int)value;
            return size > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}