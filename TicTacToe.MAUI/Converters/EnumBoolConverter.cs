using System.Globalization;

namespace TicTacToe.Converters
{
    /// <summary>
    /// This is used to convert an enumeration to a Boolean value.
    /// </summary>
    public class EnumBoolConverter : IValueConverter
    {

        /// <summary>
        /// This is used by XAML to test if an enumeration is equal to its binding value.
        /// </summary>
        /// <param name="value">The value being bound to.</param>
        /// <param name="targetType">The type of the enumerator.</param>
        /// <param name="parameter">The value of the enumeration.</param>
        /// <param name="culture">N/A</param>
        /// <returns>Returns true of the value matches the parameter; otherwise, false.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value.GetType();

            if (!(parameter is string parameterString) || value == null)
                return Binding.DoNothing;

            if (Enum.IsDefined(type, value) == false)
                return Binding.DoNothing;

            var parameterValue = Enum.Parse(type, parameterString);

            return parameterValue.Equals(value);
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

    }
}
