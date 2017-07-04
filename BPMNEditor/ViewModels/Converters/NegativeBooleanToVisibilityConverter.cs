using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Connectors

    #endregion
}
