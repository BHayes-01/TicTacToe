using System.Diagnostics;
using System.Windows.Input;
using TicTacToe.Enums;

namespace TicTacToe.CustomControls;

/// <summary>
/// Used to display none, X, or O inside a square for the tic-tac-toe board.
/// </summary>
public partial class SquareControl : ContentView
{

    /// <summary>
    /// Initializes the user control
    /// </summary>
	public SquareControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Defines the bindable command to handle the click event.
    /// </summary>
	public static readonly BindableProperty XorO_ValueProperty = BindableProperty.Create(
        propertyName: nameof(XorO_Value),
        returnType: typeof(XorO),
        declaringType: typeof(SquareControl),
        defaultValue: XorO.None,
        defaultBindingMode: BindingMode.OneWay);

    /// <summary>
    /// Defines the bindable property of the squares current value
    /// </summary>
    public static readonly BindableProperty XorO_CommandProperty = BindableProperty.Create(
        propertyName: nameof(XorO_Command),
        returnType: typeof(ICommand),
        declaringType: typeof(SquareControl),
        defaultValue: default(ICommand),
        defaultBindingMode: BindingMode.OneWay);

    /// <summary>
    /// Passes the click event as a command
    /// </summary>
    public ICommand XorO_Command
    {
        get => (ICommand)GetValue(XorO_CommandProperty);
        set => SetValue(XorO_CommandProperty, value);
    }

    /// <summary>
    /// The current value of the square
    /// </summary>
    public XorO XorO_Value
    {
        get => (XorO)GetValue(XorO_ValueProperty);
        set => SetValue(XorO_ValueProperty, value);
    }

}