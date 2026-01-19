using TicTacToe.Enums;

namespace TicTacToe.Business.Business;

public class ComputerChoiceEventArgs
{

    /// <summary>
    /// Handles the event arguments for the computer playing
    /// </summary>
    /// <param name="square">The square position chosen by the computer</param>
    /// <param name="choice">The computer's choice</param>
    public ComputerChoiceEventArgs (SquarePosition square, XorO choice)
    {
        Square = square;
        Choice = choice;
    }

    /// <summary>
    /// The computers choice X or O
    /// </summary>
    public XorO Choice { get; }

    /// <summary>
    /// The square position chosen by the computer
    /// </summary>
    public SquarePosition Square { get; }

}
