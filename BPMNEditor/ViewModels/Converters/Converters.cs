using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

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


    public class PointFromCollectionConverter : IValueConverter
    {
        private const string FirstIndexer = "FIRST";
        private const string LastIndexer = "LAST";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Point result = new Point();
            PointCollection collection = value as PointCollection;
            if (collection != null && parameter != null && collection.Count > 0)
            {
                string converterParameter = parameter.ToString().ToUpper();
                int index;
                if (int.TryParse(converterParameter, out index) && collection.Count < index)
                {
                    result = collection[index];
                }
                else switch (converterParameter)
                {
                    case FirstIndexer:
                        result = collection.First();
                        break;
                    case LastIndexer:
                        result = collection.Last();
                        break;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PointToRectangleConverter : IValueConverter
    {
        private static readonly Size RectSize = new Size(7,7);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CreateRectangle((Point) value, RectSize);
        }

        private static Rect CreateRectangle(Point point, Size rectSize)
        {
            double left = point.X - rectSize.Width/2;
            double top = point.Y - rectSize.Height/2;
            Point topLeft = new Point(left,top);
            return new Rect(topLeft, rectSize);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InstanceTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.GetType();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
