using System.Diagnostics;
using TicTacToe.Enums;

namespace TicTacToe.Business.Business;

public class GamePlay(IGamePlayViewModel viewModel)
{

    #region Fields

    private XorO[] _board = new XorO[9];
    private XorO _computerChoice;
    private bool _isX;
    private static readonly Random _random = new();

    internal readonly List<SquarePosition[]> _choiceHeirarchy =
        [
            [ SquarePosition.LeftTop, SquarePosition.RightTop, SquarePosition.LeftBottom ],
            [ SquarePosition.RightTop, SquarePosition.RightBottom, SquarePosition.LeftBottom ],
            [ SquarePosition.LeftBottom, SquarePosition.RightBottom, SquarePosition.RightTop ],
            [ SquarePosition.RightBottom, SquarePosition.LeftTop, SquarePosition.RightTop ],
            [ SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.LeftMiddle ],
            [ SquarePosition.CenterTop, SquarePosition.RightTop, SquarePosition.RightMiddle ]
        ];

    internal readonly List<SquarePosition[]> _winningCombinations =
        [
            [ SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop ],
            [ SquarePosition.LeftMiddle, SquarePosition.CenterMiddle, SquarePosition.RightMiddle ],
            [ SquarePosition.LeftBottom, SquarePosition.CenterBottom, SquarePosition.RightBottom ],
            [ SquarePosition.LeftTop, SquarePosition.LeftMiddle, SquarePosition.LeftBottom ],
            [ SquarePosition.CenterTop, SquarePosition.CenterMiddle, SquarePosition.CenterBottom ],
            [ SquarePosition.RightTop, SquarePosition.RightMiddle, SquarePosition.RightBottom ],
            [ SquarePosition.LeftTop, SquarePosition.CenterMiddle, SquarePosition.RightBottom ],
            [ SquarePosition.RightTop, SquarePosition.CenterMiddle, SquarePosition.LeftBottom ]
        ];

    #endregion Fields

    #region Properties

    /// <summary>
    /// Indicates the current state of the tic-tac-toe board
    /// </summary>
    /// <remarks>
    ///  0 | 1 | 2
    ///  ---------
    ///  3 | 4 | 5
    ///  ---------
    ///  6 | 7 | 8
    /// </remarks>
    public XorO[] Board => _board;

    /// <summary>
    /// Indicates whether the computer is playing as X or O
    /// </summary>
    public XorO ComputerChoice
    {
        get => _computerChoice;
        set => _computerChoice = value;
    }

    /// <summary>
    /// Indicates if the current turn belongs to the computer
    /// </summary>
    internal bool IsComputersTurn
    {
        get
        {
            if (_isX && (_computerChoice == XorO.O_Visible)) return false;
            if (!_isX && (_computerChoice == XorO.X_Visible)) return false;
            return true;
        }
    }

    /// <summary>
    /// Indicates if the current player is X or O
    /// </summary>
    public bool IsX
    {
        get => _isX;
        set => _isX = value;
    }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Used by the computer to find the best square to choice for its next move.
    /// </summary>
    /// <param name="threeChoices">An integer array with three choices.</param>
    /// <param name="piece">Indicates if the computer game piece is an X or O.</param>
    /// <returns>An integer into the array of the three choices; otherwise, -1 to indicate a  good choice was not found.</returns>
    internal SquarePosition CheckBestChoice(SquarePosition[] threeChoices, XorO piece)
    {
        // Create a tuple representing the state of the three squares (p0, p1, p2)
        // where pN is the XorO value on the board for threeChoices[N].
        var state = (
            _board[threeChoices[0].ToInt()],
            _board[threeChoices[1].ToInt()],
            _board[threeChoices[2].ToInt()]
        );

        // The switch expression evaluates the 'state' tuple
        var result = state switch
        {
            (XorO.None, var p1, var p2) when p1 == piece && p2 == piece =>
                0,

            (var p0, XorO.None, var p2) when p0 == piece && p2 == piece =>
                1,

            (var p0, var p1, XorO.None) when p0 == piece && p1 == piece =>
                2,

            (XorO.None, XorO.None, var p2) when p2 == piece =>
                RandomChoice([0, 1]),

            (XorO.None, var p1, XorO.None) when p1 == piece =>
                RandomChoice([0, 2]),

            (var p0, XorO.None, XorO.None) when p0 == piece =>
                RandomChoice([1, 2]),

            (XorO.None, var p1, var p2) when p1 == piece && p2 == piece =>
                0,

            (var p0, XorO.None, var p2) when p0 == piece && p2 == piece =>
                1,

            (var p0, var p2, XorO.None) when p0 == piece && p2 == piece =>
                2,

            _ => -1   // Default Case
        };


        if (result == -1)
            return SquarePosition.Invalid;

        return threeChoices[result];
    }

    /// <summary>
    /// Randomly returns one object of the choice of objects
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    /// <param name="choices"></param>
    /// <returns>An object</returns>
    internal T RandomChoice<T>(T[] choices)
    {
        int index = _random.Next(choices.Count());

        return choices[index];
    }

    /// <summary>
    /// Check if computer should play next
    /// </summary>
    public void CheckIfComputerPlay()
    {
        if (viewModel.TwoPlayer) return;
        if (viewModel.GameOver) return;
        if (!IsComputersTurn) return;

        Thread.Sleep(200);  // add delay to computer response;
        LetComputerPlayTurn();
    }

    /// <summary>
    /// Check for best blocking move
    /// </summary>
    /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
    internal SquarePosition CheckForBestBlockingMove(XorO computerChoice)
    {
        // pick corner edge position if available
        foreach (var threeInARow in _choiceHeirarchy)
        {
            var open = CheckBestChoice(threeInARow, computerChoice);
            if (open != SquarePosition.Invalid)
                return open;
        }

        return SquarePosition.Invalid;
    }

    /// <summary>
    /// Check for best blocking move
    /// </summary>
    /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
    internal SquarePosition CheckForSpecialBlockingMove(XorO computerChoice, XorO opponentChoice)
    {
        if (_board[SquarePosition.CenterMiddle.ToInt()] != computerChoice)
            return SquarePosition.Invalid;

        if ((_board[SquarePosition.LeftTop.ToInt()] == opponentChoice && _board[SquarePosition.RightBottom.ToInt()] == opponentChoice)
            || _board[SquarePosition.RightTop.ToInt()] == opponentChoice && _board[SquarePosition.LeftBottom.ToInt()] == opponentChoice)
        {
            if (_board[SquarePosition.CenterTop.ToInt()] == XorO.None && _board[SquarePosition.CenterBottom.ToInt()] == XorO.None)
                return SquarePosition.CenterTop;

            if (_board[SquarePosition.LeftMiddle.ToInt()] == XorO.None && _board[SquarePosition.RightMiddle.ToInt()] == XorO.None)
                return SquarePosition.LeftMiddle;
        }

        if ((_board[SquarePosition.CenterTop.ToInt()] == opponentChoice || _board[SquarePosition.RightTop.ToInt()] == opponentChoice)
            && (_board[SquarePosition.LeftMiddle.ToInt()] == opponentChoice || _board[SquarePosition.LeftBottom.ToInt()] == opponentChoice)
            && _board[SquarePosition.LeftTop.ToInt()] == XorO.None)
        {
            return SquarePosition.LeftTop;
        }

        if ((_board[SquarePosition.CenterTop.ToInt()] == opponentChoice || _board[SquarePosition.LeftTop.ToInt()] == opponentChoice)
            && (_board[SquarePosition.RightMiddle.ToInt()] == opponentChoice || _board[SquarePosition.RightBottom.ToInt()] == opponentChoice)
            && _board[SquarePosition.RightTop.ToInt()] == XorO.None)
        {
            return SquarePosition.RightTop;
        }

        if ((_board[5] == opponentChoice || _board[SquarePosition.RightTop.ToInt()] == opponentChoice)
            && (_board[SquarePosition.CenterBottom.ToInt()] == opponentChoice || _board[SquarePosition.LeftBottom.ToInt()] == opponentChoice)
            && _board[SquarePosition.RightBottom.ToInt()] == XorO.None)
        {
            return SquarePosition.RightBottom;
        }

        if ((_board[SquarePosition.CenterBottom.ToInt()] == opponentChoice || _board[SquarePosition.RightBottom.ToInt()] == opponentChoice)
            && (_board[SquarePosition.LeftMiddle.ToInt()] == opponentChoice || _board[SquarePosition.LeftTop.ToInt()] == opponentChoice)
            && _board[SquarePosition.LeftBottom.ToInt()] == XorO.None)
        {
            return SquarePosition.LeftBottom;
        }

        return SquarePosition.Invalid;
    }

    /// <summary>
    /// Picks a random corner to play in.
    /// </summary>
    /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
    internal SquarePosition PickRandomCorner()
    {
        if ((viewModel.LeftTopChoice == XorO.None)
            || (viewModel.RightTopChoice == XorO.None)
            || (viewModel.LeftBottomChoice == XorO.None)
            || (viewModel.RightBottomChoice == XorO.None))
        {
            int index = _random.Next(4);  // randomly pick between the four choices

            SquarePosition open = SquarePosition.Invalid;
            while (open == SquarePosition.Invalid)
            {
                if (index == 0 && viewModel.LeftTopChoice == XorO.None)
                {
                    open = SquarePosition.LeftTop;
                    break;
                }
                if (index <= 1 && viewModel.RightTopChoice == XorO.None)
                {
                    open = SquarePosition.RightTop;
                    break;
                }
                if (index <= 2 && viewModel.LeftBottomChoice == XorO.None)
                {
                    open = SquarePosition.LeftBottom;
                    break;
                }
                if (index <= 3 && viewModel.RightBottomChoice == XorO.None)
                {
                    open = SquarePosition.RightBottom;
                    break;
                }
                if (open == SquarePosition.Invalid) index = 0;
            }
            return open;
        }

        return SquarePosition.Invalid;
    }

    /// <summary>
    /// Check if there is a winner of the game is a tie
    /// </summary>
    public void CheckIfWinnerOrDraw()
    {

        viewModel.WinningSelection = -1;

        int i = 0;
        foreach (var threeInARow in _winningCombinations)
        {
            if ((_board[threeInARow[0].ToInt()] != XorO.None)
                && (_board[threeInARow[0].ToInt()] == _board[threeInARow[1].ToInt()]
                && _board[threeInARow[0].ToInt()] == _board[threeInARow[2].ToInt()]))
            {
                viewModel.WinningSelection = i;
                viewModel.UpdateWinningLine();
                viewModel.HasWinner = true;
                viewModel.GameOver = true;

                viewModel.Instructions = $"'{(_board[threeInARow[0].ToInt()] == XorO.X_Visible ? "X" : "O")}' Wins";
                break;
            }
            i++;
        }

        if (!viewModel.GameOver)
        {
            var count = _board.Count(o => o == XorO.None);

            if (count <= 1)
            {
                var isTie = _board.All(o => o != XorO.None);
                if (isTie)
                {
                    // all possible moved made, so game is a tie.
                    viewModel.GameOver = true;
                    viewModel.Instructions = "Tie";
                }
                else
                {
                    // one move left, if it is not a possible winning move end early.
                    bool canWin = false;

                    var _board2 = new XorO[_board.Length];
                    Array.Copy(_board, _board2, _board2.Length);

                    for (int j = 0; j < _board2.Length; j++)
                    {
                        if (_board2[j] == XorO.None)
                        {
                            _board2[j] = _isX ? XorO.X_Visible : XorO.O_Visible;
                            break;
                        }
                    }

                    foreach (var threeInARow in _winningCombinations)
                    {
                        if (_board2[threeInARow[0].ToInt()] == _board2[threeInARow[1].ToInt()]
                            && _board2[threeInARow[0].ToInt()] == _board2[threeInARow[2].ToInt()])
                        {
                            canWin = true;
                            break;
                        }
                    }

                    if (!canWin)
                    {
                        foreach(SquarePosition position in Enum.GetValues(typeof(SquarePosition)))
                        {
                            if (position == SquarePosition.Invalid)
                                continue;

                            if (_board2[position.ToInt()] == XorO.None)
                            {
                                Play(position);
                                break;
                            }
                        }

                        viewModel.GameOver = true;
                        viewModel.Instructions = "Tie";
                    }

                }

            }
        }
    }

    /// <summary>
    /// Used by the computer to identify that there is one play away from winning.
    /// </summary>
    /// <param name="threeInARow">A winning combination of moves.</param>
    /// <param name="piece">Indicates if the game piece is an X or O.</param>
    /// <returns>An integer representing the winning move into the array of the three choices; otherwise, -1 to indicate a winning choice was not found.</returns>
    internal SquarePosition CheckShouldPlay(SquarePosition[] threeInARow, XorO piece)
    {
        if ((_board[threeInARow[0].ToInt()] == XorO.None)
            && (_board[threeInARow[1].ToInt()] == piece) && (_board[threeInARow[2].ToInt()] == piece))
            return threeInARow[0]; // first option

        if ((_board[threeInARow[0].ToInt()] == piece)
            && (_board[threeInARow[1].ToInt()] == XorO.None) && (_board[threeInARow[2].ToInt()] == piece))
            return threeInARow[1]; //second option

        if ((_board[threeInARow[0].ToInt()] == piece)
            && (_board[threeInARow[1].ToInt()] == piece) && (_board[threeInARow[2].ToInt()] == XorO.None))
            return threeInARow[2]; // third option

        return SquarePosition.Invalid; // no options
    }

    /// <summary>
    /// Play as a the computer
    /// </summary>
    internal void LetComputerPlayTurn()
    {
        SquarePosition open;

        var computerChoice = _isX ? XorO.X_Visible : XorO.O_Visible;
        var opponentChoice = _isX ? XorO.O_Visible : XorO.X_Visible;


        // This should also randomly pick a corner square if the computer goes first.
        // always pick center if open
        if (viewModel.CenterMiddleChoice == XorO.None)
        {
            Play(SquarePosition.CenterMiddle);
            return;
        }

        // check for winning move
        foreach (var threeInARow in _winningCombinations)
        {
            open = CheckShouldPlay(threeInARow, computerChoice);
            if (open != SquarePosition.Invalid)
            {
                Play(open);
                return;
            }
        }

        // check to make sure opponent doesn't win in next move
        foreach (var threeInARow in _winningCombinations)
        {
            open = CheckShouldPlay(threeInARow, opponentChoice);
            if (open != SquarePosition.Invalid)
            {
                Play(open);
                return;
            }
        }

        // check for special condition of two opposite corners selected.
        open = CheckForSpecialBlockingMove(computerChoice, opponentChoice);
        if (open >= 0)
        {
            Play(open);
            return;
        }

        // find the best blocking move
        open = CheckForBestBlockingMove(computerChoice);
        if (open >= 0)
        {
            Play(open);
            return;
        }

        // pick an edge randomly
        open = PickRandomCorner();
        if (open >= 0)
        {
            Play(open);
            return;
        }

        // pick first open spot
        for (int i = 0; i < _board.Length; i++)
        {
            if (_board[i] == XorO.None)
            {
                Play((SquarePosition)i);
                return;
            }
        }

    }

    /// <summary>
    /// Handles the selection of a square
    /// </summary>
    /// <param name="currentChoice">The current value of the square</param>
    /// <returns>The new value of the square.</returns>
    public XorO PickSquare(XorO currentChoice)
    {
        if (viewModel.GameOver) return currentChoice;
        if (currentChoice != XorO.None) return currentChoice;

        _isX = !_isX;
        UpdateInstructions();

        return _isX ? XorO.O_Visible : XorO.X_Visible;
    }

    /// <summary>
    /// Sets the square based on the computer's choice.
    /// </summary>
    /// <param name="choice">An integer that represents a tic-tac-toe square position.</param>
    internal void Play(SquarePosition choice)
    {
        switch (choice)
        {
            case SquarePosition.LeftTop:
                {
                    viewModel.LeftTopChoice = PickSquare(viewModel.LeftTopChoice);
                    break;
                }
            case SquarePosition.CenterTop:
                {
                    viewModel.CenterTopChoice = PickSquare(viewModel.CenterTopChoice);
                    break;
                }
            case SquarePosition.RightTop:
                {
                    viewModel.RightTopChoice = PickSquare(viewModel.RightTopChoice);
                    break;
                }
            case SquarePosition.LeftMiddle:
                {
                    viewModel.LeftMiddleChoice = PickSquare(viewModel.LeftMiddleChoice);
                    break;
                }
            case SquarePosition.CenterMiddle:
                {
                    viewModel.CenterMiddleChoice = PickSquare(viewModel.CenterMiddleChoice);
                    break;
                }
            case SquarePosition.RightMiddle:
                {
                    viewModel.RightMiddleChoice = PickSquare(viewModel.RightMiddleChoice);
                    break;
                }
            case SquarePosition.LeftBottom:
                {
                    viewModel.LeftBottomChoice = PickSquare(viewModel.LeftBottomChoice);
                    break;
                }
            case SquarePosition.CenterBottom:
                {
                    viewModel.CenterBottomChoice = PickSquare(viewModel.CenterBottomChoice);
                    break;
                }
            case SquarePosition.RightBottom:
                {
                    viewModel.RightBottomChoice = PickSquare(viewModel.RightBottomChoice);
                    break;
                }

            case SquarePosition.Invalid:
                Debug.WriteLine("Invalid Choice");
                break;
        }
    }

    /// <summary>
    /// Update the instructions for the next step.
    /// </summary>
    public void UpdateInstructions()
    {
        var turn = _isX ? "X" : "O";
        viewModel.Instructions = $"'{turn}' goes next.";
    }

    #endregion Methods

}
