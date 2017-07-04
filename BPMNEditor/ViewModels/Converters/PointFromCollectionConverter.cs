using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BPMNEditor.ViewModels.Converters
{
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
}