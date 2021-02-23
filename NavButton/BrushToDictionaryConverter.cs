using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace NavButton
{
    /// <summary>
    /// Converter to wrap a color into a dictionary.
    /// </summary>
    public class BrushToDictionaryConverter : IValueConverter
    {
        /// <summary>
        /// Returns a dictionary containing a brush as value and 
        /// a string representation of the brush as key.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush scb)
                return new Dictionary<string, Brush> { { "black", scb } };

            return new Dictionary<string, Brush> { { "black", new SolidColorBrush(Colors.Transparent) } };
        }

        /// <summary>
        /// Returns a brush from the dictionary assuming the provided value is a dictionary containing
        /// brushes as values.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Dictionary<string, Brush> dict && dict.Any())
                return dict.First().Value;

            return new SolidColorBrush(Colors.Transparent);
        }
    }
}

