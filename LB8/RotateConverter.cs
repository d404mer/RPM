using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Lab3_2sem_3course
{
    public class RotateConverter : IValueConverter
    {
        public static readonly RotateConverter Instance = new();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isPressed && isPressed)
            {
                return parameter switch
                {
                    "Left" => new RotateTransform(-90),
                    "Right" => new RotateTransform(90),
                    _ => new RotateTransform(0)
                };
            }
            return new RotateTransform(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
