namespace TicTacToe.Enums;

public static class EnumExtensions
{

    /// <summary>
    /// Gets the underlying integer value of any enum member.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="enumValue">The enum member.</param>
    /// <returns>The underlying int value.</returns>
    public static int ToInt<T>(this T enumValue) where T : Enum
    {
        // This is where the required explicit cast happens internally.
        // Convert.ToInt32 handles all underlying enum types (byte, short, etc.).
        return Convert.ToInt32(enumValue);
    }

}
