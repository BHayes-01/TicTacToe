using System.Globalization;

namespace TicTacToe.Converters
{
    public class EnumVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value.GetType();

            if (!(parameter is string parameterString) || value == null)
                return Activator.CreateInstance(type);

            if (Enum.IsDefined(type, value) == false)
                return Activator.CreateInstance(type);

            var parameterValue = Enum.Parse(type, parameterString);

            return parameterValue.Equals(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
