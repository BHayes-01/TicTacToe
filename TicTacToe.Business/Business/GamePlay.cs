using System.Diagnostics;
using TicTacToe.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TicTacToe.Business.Business;

public class GamePlay() : ObservableObject, IGamePlay
{
    #region Events

    public event EventHandler<ComputerChoiceEventArgs>? ComputerPlayed;

    #endregion Events

    #region Fields

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

    private static readonly Random _random = new();
    private XorO[] _board = new XorO[9];
    private bool _computerStarts;
    private bool _gameOver;
    private bool _hasWinner;
    private string _instructions = string.Empty;
    private bool _isX;
    private bool _twoPlayer;

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
    public XorO ComputerChoice { get; set; }

    /// <summary>
    /// Delay time for computer in milliseconds
    /// </summary>
    public int DelayMilliseconds { get; set; } = 1000;

    /// <summary>
    /// Indicates that a winning combination has been found
    /// </summary>
    public int WinningSelection { get; set; } = -1;

    /// <summary>
    /// Indicates the computer is thinking
    /// </summary>
    internal bool IsThinking { get; set; }

    #endregion Properties

    #region Observable Properties 

    /// <summary>
    /// Indicates if the computer starts
    /// </summary>
    public bool ComputerStarts
    {
        get => _computerStarts;
        set => SetProperty(ref _computerStarts, value);
    }

    /// <summary>
    /// Indicates that the game is over
    /// </summary>
    public bool GameOver
    {
        get => _gameOver;
        set => SetProperty(ref _gameOver, value);
    }

    /// <summary>
    /// Indicates that the game has a winner, versus a tie
    /// </summary>
    public bool HasWinner
    {
        get => _hasWinner;
        set => SetProperty(ref _hasWinner, value);
    }

    /// <summary>
    /// Brief description of next step that is displayed
    /// </summary>
    public string Instructions
    {
        get => _instructions;
        set => SetProperty(ref _instructions, value);
    }

    /// <summary>
    /// Indicates if the current player is X or O
    /// </summary>
    public bool IsX
    {
        get => _isX;
        set => SetProperty(ref _isX, value);
    }

    /// <summary>
    /// Indicates if it is a two player game; otherwise, one player
    /// </summary>
    public bool TwoPlayer
    {
        get => _twoPlayer;
        set => SetProperty(ref _twoPlayer, value);
    }

    #endregion Observable Properties 

    #region Tic-Tac-Toe Square Properties

    /// <summary>
    /// [7] The current value of the center bottom square
    /// </summary>
    public XorO CenterBottomChoice
    {
        get => _board[7];
        set => UpdatePlay(7, value);
    }

    /// <summary>
    /// [4] The current value of the center square
    /// </summary>
    public XorO CenterMiddleChoice
    {
        get => _board[4];
        set => UpdatePlay(4, value);
    }

    /// <summary>
    /// [1] The current value of the center top square
    /// </summary>
    public XorO CenterTopChoice
    {
        get => _board[1];
        set => UpdatePlay(1, value);
    }

    /// <summary>
    /// [6] The current value of the left side bottom square
    /// </summary>
    public XorO LeftBottomChoice
    {
        get => _board[6];
        set => UpdatePlay(6, value);
    }

    /// <summary>
    /// [3] The current value of the left side middle square
    /// </summary>
    public XorO LeftMiddleChoice
    {
        get => _board[3];
        set => UpdatePlay(3, value);
    }

    /// <summary>
    /// [0] The current value of the left side top square
    /// </summary>
    public XorO LeftTopChoice
    {
        get => _board[0];
        set => UpdatePlay(0, value);
    }

    /// <summary>
    /// [8] The current value of the right side bottom square
    /// </summary>
    public XorO RightBottomChoice
    {
        get => _board[8];
        set => UpdatePlay(8, value);
    }

    /// <summary>
    /// [5] The current value of the right side middle square
    /// </summary>
    public XorO RightMiddleChoice
    {
        get => _board[5];
        set => UpdatePlay(5, value);
    }

    /// <summary>
    /// [2] The current value of the right side top square
    /// </summary>
    public XorO RightTopChoice
    {
        get => _board[2];
        set => UpdatePlay(2, value);
    }

    #endregion Tic-Tac-Toe Square Properties

    #region Methods

    /// <summary>
    /// Check if computer should play next
    /// </summary>
    public bool CheckIfComputerPlay()
    {
        if (TwoPlayer) return false;
        if (GameOver) return false;
        if (!IsComputersTurn()) return false;

        return true;
    }

    /// <summary>
    /// Resets values to play again
    /// </summary>
    public void PlayAgain()
    {
        IsX = false;
        HasWinner = false;
        GameOver = false;
        IsThinking = false;

        WinningSelection = -1;
        ComputerChoice = ComputerStarts ? XorO.O_Visible : XorO.X_Visible;
        for (int i = 0; i < Board.Count(); i++)
        {
            Board[i] = XorO.None;
        }

        UpdateInstructions();

        CheckIfComputerCanPlay();
    }

    /// <summary>
    /// Update the instructions for the next step.
    /// </summary>
    public void UpdateInstructions()
    {
        if (GameOver) return;

        var turn = IsX ? "X" : "O";
        Instructions = $"'{turn}' goes next.";
    }

    public void UpdateInstructionsReverse()
    {
        if (GameOver) return;

        var turn = IsX ? "O" : "X";
        Instructions = $"'{turn}' goes next.";
    }

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
    /// Checks whether the computer is able to play its turn and, if so, initiates the computer's move.
    /// </summary>
    /// <remarks>This method introduces a short delay before allowing the computer to play, which can
    /// be used to simulate thinking time or improve user experience in turn-based games. Intended for internal use
    /// within the game loop or turn management logic.</remarks>
    internal void CheckIfComputerCanPlay()
    {
        if (CheckIfComputerPlay())
            LetComputerPlayTurn();
    }

    /// <summary>
    /// Check if there is a winner of the game is a tie
    /// </summary>
    internal void CheckIfWinnerOrDraw()
    {
        WinningSelection = -1;

        int i = 0;
        foreach (var threeInARow in _winningCombinations)
        {
            if ((_board[threeInARow[0].ToInt()] != XorO.None)
                && (_board[threeInARow[0].ToInt()] == _board[threeInARow[1].ToInt()]
                && _board[threeInARow[0].ToInt()] == _board[threeInARow[2].ToInt()]))
            {
                WinningSelection = i;

                GameOver = true;
                HasWinner = true;

                Instructions = $"'{(_board[threeInARow[0].ToInt()] == XorO.X_Visible ? "X" : "O")}' Wins";
                break;
            }
            i++;
        }

        if (!GameOver)
        {
            var count = _board.Count(o => o == XorO.None);

            if (count <= 1)
            {
                var isTie = _board.All(o => o != XorO.None);
                if (isTie)
                {
                    // all possible moved made, so game is a tie.
                    GameOver = true;
                    Instructions = "Tie";
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
                            _board2[j] = IsX ? XorO.X_Visible : XorO.O_Visible;
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
                        foreach (SquarePosition position in Enum.GetValues(typeof(SquarePosition)))
                        {
                            if (position == SquarePosition.Invalid)
                                continue;

                            if (_board2[position.ToInt()] == XorO.None)
                            {
                                Play(position);
                                break;
                            }
                        }

                        GameOver = true;
                        Instructions = "Tie";
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
    /// Indicates if the current turn belongs to the computer
    /// </summary>
    internal bool IsComputersTurn()
    {
        if (ComputerChoice == XorO.None) return false;
        if (IsX && (ComputerChoice == XorO.O_Visible)) return false;
        if (!IsX && (ComputerChoice == XorO.X_Visible)) return false;
        return true;
    }

    /// <summary>
    /// Play as a the computer
    /// </summary>
    internal void LetComputerPlayTurn()
    {
        SquarePosition open;

        var computerChoice = IsX ? XorO.X_Visible : XorO.O_Visible;
        var opponentChoice = IsX ? XorO.O_Visible : XorO.X_Visible;

        // This should also randomly pick a corner square if the computer goes first.
        // always pick center if open
        if (CenterMiddleChoice == XorO.None)
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
    /// Picks a random corner to play in.
    /// </summary>
    /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
    internal SquarePosition PickRandomCorner()
    {
        if ((LeftTopChoice == XorO.None)
            || (RightTopChoice == XorO.None)
            || (LeftBottomChoice == XorO.None)
            || (RightBottomChoice == XorO.None))
        {
            int index = _random.Next(4);  // randomly pick between the four choices

            SquarePosition open = SquarePosition.Invalid;
            while (open == SquarePosition.Invalid)
            {
                if (index == 0 && LeftTopChoice == XorO.None)
                {
                    open = SquarePosition.LeftTop;
                    break;
                }
                if (index <= 1 && RightTopChoice == XorO.None)
                {
                    open = SquarePosition.RightTop;
                    break;
                }
                if (index <= 2 && LeftBottomChoice == XorO.None)
                {
                    open = SquarePosition.LeftBottom;
                    break;
                }
                if (index <= 3 && RightBottomChoice == XorO.None)
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
    /// Sets the square based on the computer's choice.
    /// </summary>
    /// <param name="choice">An integer that represents a tic-tac-toe square position.</param>
    internal void Play(SquarePosition choice)
    {
        if (IsThinking) return; // disable board while thinking;

        ComputerPlayed?.Invoke(this, new ComputerChoiceEventArgs(choice, IsSquareXorO()));
    }

    /// <summary>
    /// Give a lsight pause before the computer plays
    /// </summary>
    /// <param name="action"></param>
    internal async Task PretendComputerIsThinking(Action action)
    {
        if (IsThinking)
            return;

        // only delay if the computer is going to play
        if (!GameOver && !TwoPlayer && DelayMilliseconds > 0 && !IsComputersTurn())
        {
            IsThinking = true;
            try
            {
                UpdateInstructionsReverse();
                await Task.Delay(DelayMilliseconds);
                UpdateInstructions();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {nameof(PretendComputerIsThinking)}.\r\n{ex}");
            }
            finally
            {
                IsThinking = false;
            }
        }

        action();
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
    /// Update the game board after a square has been picked.
    /// </summary>
    internal void UpdatePlay(int square, XorO value)
    {
        if (IsThinking) return; // disable board while thinking;

        if (_board[square] == value) return;

        _board[square] = value;
        _ = PretendComputerIsThinking(() =>
            {
                IsX = !IsX;
                UpdateInstructions();
                CheckIfComputerCanPlay();
                CheckIfWinnerOrDraw();
            }
        );
    }

    private XorO IsSquareXorO()
    {
        return IsX ? XorO.X_Visible : XorO.O_Visible;
    }

    #endregion Methods

}
