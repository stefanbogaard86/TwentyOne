using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TwentyOne.Converters
{
    public class IntToDiceImageSourceConverter : IValueConverter
    {
        public const string DiceImage = "{0}.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int intValue))
                return value;

            return string.Format(DiceImage, intValue.ToWord());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
