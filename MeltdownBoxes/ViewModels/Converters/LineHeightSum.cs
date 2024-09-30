using System.Globalization;
using System.Windows.Data;

namespace MeltdownBoxes.ViewModels.Converters
{
    public class LineHeightSum : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double lineHeight)
            {
                return (lineHeight * 2);
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
