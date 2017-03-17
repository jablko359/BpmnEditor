using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{

    #region  Visibility

    public class NegativeBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool itemVisibility = (bool)value;
                Visibility result = itemVisibility ? Visibility.Collapsed : Visibility.Visible;
                return result;
            }
            catch (Exception)
            {
                throw new IncorrectConverterValueException(value, targetType);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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

    public class BooleanToHiddenVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = (bool)value;
            return isVisible ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    
}
