using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BPMNEditor.ViewModels.Converters
{
    public class PointToRectangleConverter : IValueConverter
    {
        private static readonly Size RectSize = new Size(7, 7);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CreateRectangle((Point)value, RectSize);
        }

        private static Rect CreateRectangle(Point point, Size rectSize)
        {
            double left = point.X - rectSize.Width / 2;
            double top = point.Y - rectSize.Height / 2;
            Point topLeft = new Point(left, top);
            return new Rect(topLeft, rectSize);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}