using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;
using TicTacToe.Enums;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This view model is used to handle game play.
    /// This includes the decision made by the computer.
    /// </summary>
    public partial class GamePlayViewModel : ObservableObject, IQueryAttributable
    {

        #region Fields

        internal XorO[] _board = new XorO[9];
        private XorO _computerChoice;
        private bool _isX;

        internal readonly List<int[]> _choiceHeirarchy = new()
        {
            new[] { 0, 2, 6 },
            new[] { 2, 8, 6 },
            new[] { 0, 1, 3 },
            new[] { 1, 2, 5 },
            new[] { 5, 8, 7 },
            new[] { 3, 6, 7 }
        };

        internal readonly List<int[]> _winningCombinations = new()
        {
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },
            new[] { 0, 3, 6 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },
            new[] { 0, 4, 8 },
            new[] { 2, 4, 6 }
        };

        #endregion Fields

        #region Constructor

        /// <summary>
        /// This method is supposed to get the parameter arguments that are passed in from the main start page.
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // get the value of Two Player here.  

            if (!query.ContainsKey(nameof(TwoPlayer)))
            { }
            else if (bool.TryParse(HttpUtility.UrlDecode((query[nameof(TwoPlayer)] ?? string.Empty).ToString()), out bool twoPlayer))
                TwoPlayer = twoPlayer;

            // get the value of Computer Starts here.
            if (!query.ContainsKey(nameof(ComputerStarts)))
            { }
            else if (bool.TryParse(HttpUtility.UrlDecode((query[nameof(ComputerStarts)] ?? string.Empty).ToString()), out bool computerStarts))
                ComputerStarts = computerStarts;

            PlayAgainClick();
        }

        #endregion Constructor

        #region Auto Properties From Fields

        /// <summary>
        /// Indicates if the computer starts
        /// </summary>
        [ObservableProperty]
        private bool _computerStarts;

        /// <summary>
        /// Indicates that the game is over
        /// </summary>
        [ObservableProperty]
        private bool _gameOver;

        /// <summary>
        /// The size of the tic-tac-toe board, the width and height needs to be the same
        /// </summary>
        [ObservableProperty]
        private double _gridSize;

        /// <summary>
        /// Indicates that the game has a winner, versus a tie
        /// </summary>
        [ObservableProperty]
        private bool _hasWinner;

        /// <summary>
        /// Brief description of next step that is displayed
        /// </summary>
        [ObservableProperty]
        private string _instructions;

        /// <summary>
        /// Used to hide the Title if the height is too small
        /// </summary>
        [ObservableProperty]
        private double _topRowHeight;

        /// <summary>
        /// Indicates if it is a two player game; otherwise, one player
        /// </summary>
        [ObservableProperty]
        private bool _twoPlayer;

        /// <summary>
        /// Indicates that a winning combination has been found
        /// </summary>
        [ObservableProperty]
        private int _winningSelection;

        /// <summary>
        /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
        /// </summary>
        [ObservableProperty]
        private double _winningX1;

        /// <summary>
        /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
        /// </summary>
        [ObservableProperty]
        private double _winningX2;

        /// <summary>
        /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
        /// </summary>
        [ObservableProperty]
        private double _winningY1;

        /// <summary>
        /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
        /// </summary>
        [ObservableProperty]
        private double _winningY2;

        #endregion Auto Properties From Fields

        #region Tic-Tac-Toe Square Auto Generated Relay Commands

        /// <summary>
        /// [0] Handles the click event for the left side top square
        /// </summary>
        [RelayCommand]
        internal void LeftTopClick() { LeftTopChoice = PickSquare(LeftTopChoice); }

        /// <summary>
        /// [1] Handles the click event for the center top square
        /// </summary>
        [RelayCommand]
        internal void CenterTopClick() { CenterTopChoice = PickSquare(CenterTopChoice); }

        /// <summary>
        /// [2] Handles the click event for the right side top square
        /// </summary>
        [RelayCommand]
        internal void RightTopClick() { RightTopChoice = PickSquare(RightTopChoice); }

        /// <summary>
        /// [3] Handles the click event for the left side middle square
        /// </summary>
        [RelayCommand]
        internal void LeftMiddleClick() { LeftMiddleChoice = PickSquare(LeftMiddleChoice); }

        /// <summary>
        /// [4] Handles the click event for the center square
        /// </summary>
        [RelayCommand]
        internal void CenterMiddleClick() { CenterMiddleChoice = PickSquare(CenterMiddleChoice); }

        /// <summary>
        /// [5] Handles the click event for the right side middle square
        /// </summary>
        [RelayCommand]
        internal void RightMiddleClick() { RightMiddleChoice = PickSquare(RightMiddleChoice); }

        /// <summary>
        /// [6] Handles the click event for the left side bottom square
        /// </summary>
        [RelayCommand]
        internal void LeftBottomClick() { LeftBottomChoice = PickSquare(LeftBottomChoice); }

        /// <summary>
        /// [7] Handles the click event for the center bottom square
        /// </summary>
        [RelayCommand]
        internal void CenterBottomClick() { CenterBottomChoice = PickSquare(CenterBottomChoice); }

        /// <summary>
        /// [8] Handles the click event for the right side bottom square
        /// </summary>
        [RelayCommand]
        internal void RightBottomClick() { RightBottomChoice = PickSquare(RightBottomChoice); }

        #endregion Tic-Tac-Toe Square Relay Commands

        #region Auto Relay Commands from Methods

        /// <summary>
        /// PlayAgainClick to default values
        /// </summary>
        [RelayCommand]
        internal void PlayAgainClick()
        {
            _isX = false;
            HasWinner = false;
            GameOver = false;
            WinningSelection = -1;
            _computerChoice = ComputerStarts ? XorO.O_Visible : XorO.X_Visible;
            for (int i = 0; i < _board.Count(); i++)
            {
                _board[i] = XorO.None;
            }

            OnPropertyChanged(nameof(LeftTopChoice));
            OnPropertyChanged(nameof(CenterTopChoice));
            OnPropertyChanged(nameof(RightTopChoice));
            OnPropertyChanged(nameof(LeftMiddleChoice));
            OnPropertyChanged(nameof(CenterMiddleChoice));
            OnPropertyChanged(nameof(RightMiddleChoice));
            OnPropertyChanged(nameof(LeftBottomChoice));
            OnPropertyChanged(nameof(CenterBottomChoice));
            OnPropertyChanged(nameof(RightBottomChoice));

            UpdateInstructions();

            CheckIfComputerPlay();
        }

        /// <summary>
        /// Exit the program
        /// </summary>
        [RelayCommand]
        internal void QuitClick()
        {
            Environment.Exit(0);
        }

        #endregion Auto Relay Commands from Methods

        #region Tic-Tac-Toe Square Properties

        /// <summary>
        /// [0] The current value of the left side top square
        /// </summary>
        public XorO LeftTopChoice
        {
            get => _board[0];
            set
            {
                if (SetProperty(ref _board[0], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [1] The current value of the center top square
        /// </summary>
        public XorO CenterTopChoice
        {
            get => _board[1];
            set
            {
                if (SetProperty(ref _board[1], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [2] The current value of the right side top square
        /// </summary>
        public XorO RightTopChoice
        {
            get => _board[2];
            set
            {
                if (SetProperty(ref _board[2], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [3] The current value of the left side middle square
        /// </summary>
        public XorO LeftMiddleChoice
        {
            get => _board[3];
            set
            {
                if (SetProperty(ref _board[3], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [4] The current value of the center square
        /// </summary>
        public XorO CenterMiddleChoice
        {
            get => _board[4];
            set
            {
                if (SetProperty(ref _board[4], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [5] The current value of the right side middle square
        /// </summary>
        public XorO RightMiddleChoice
        {
            get => _board[5];
            set
            {
                if (SetProperty(ref _board[5], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [6] The current value of the left side bottom square
        /// </summary>
        public XorO LeftBottomChoice
        {
            get => _board[6];
            set
            {
                if (SetProperty(ref _board[6], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [7] The current value of the center bottom square
        /// </summary>
        public XorO CenterBottomChoice
        {
            get => _board[7];
            set
            {
                if (SetProperty(ref _board[7], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        /// <summary>
        /// [8] The current value of the right side bottom square
        /// </summary>
        public XorO RightBottomChoice
        {
            get => _board[8];
            set
            {
                if (SetProperty(ref _board[8], value))
                {
                    CheckIfWinnerOrDraw();
                    CheckIfComputerPlay();
                }
            }
        }

        #endregion Tic-Tac-Toe Square Properties

        #region Properties

        /// <summary>
        /// Indicates if the current turn belongs to the computer
        /// </summary>
        public bool IsComputersTurn
        {
            get
            {
                if (_isX && (_computerChoice == XorO.O_Visible)) return false;
                if (!_isX && (_computerChoice == XorO.X_Visible)) return false;
                return true;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Used by the computer to find the best square to choice for its next move.
        /// </summary>
        /// <param name="threeChoices">An integer array with three choices.</param>
        /// <param name="piece">Indicates if the computer game piece is an X or O.</param>
        /// <returns>An integer into the array of the three choices; otherwise, -1 to indicate a  good choice was not found.</returns>
        /// <remarks>
        ///  0 | 1 | 2
        ///  ---------
        ///  3 | 4 | 5
        ///  ---------
        ///  6 | 7 | 8
        /// </remarks>
        internal int CheckBestChoice(int[] threeChoices, XorO piece)
        {

            if (_board[threeChoices[0]] == piece && (_board[threeChoices[1]] == XorO.None || _board[threeChoices[2]] == XorO.None))
            {
                if ((_board[threeChoices[1]] == XorO.None) && (_board[threeChoices[2]] == XorO.None))
                {
                    int index = Random.Shared.Next(2);  // randomly pick between the two choices
                    return index == 0 ? 1 : 2;
                }

                if ((_board[threeChoices[1]] == piece) && (_board[threeChoices[2]] == XorO.None))
                    return 2;

                if ((_board[threeChoices[2]] == piece) && (_board[threeChoices[1]] == XorO.None))
                    return 1;
            }

            if ((_board[threeChoices[1]] == piece) && (_board[threeChoices[0]] == XorO.None && _board[threeChoices[2]] == XorO.None))
            {
                if ((_board[threeChoices[0]] == XorO.None) && (_board[threeChoices[2]] == XorO.None))
                {
                    int index = Random.Shared.Next(2);  // randomly pick between the two choices
                    return index == 0 ? 0 : 2;
                }

                if ((_board[threeChoices[0]] == piece) && (_board[threeChoices[2]] == XorO.None))
                    return 2;

                if ((_board[threeChoices[2]] == piece) && (_board[threeChoices[0]] == XorO.None))
                    return 0;
            }

            if ((_board[threeChoices[2]] == piece) && (_board[threeChoices[0]] == XorO.None || _board[threeChoices[1]] == XorO.None))
            {
                if ((_board[threeChoices[0]] == XorO.None) && (_board[threeChoices[1]] == XorO.None))
                {
                    int index = Random.Shared.Next(2);  // randomly pick between the two choices
                    return index == 0 ? 0 : 1;
                }

                if ((_board[threeChoices[0]] == piece) && (_board[threeChoices[1]] == XorO.None))
                    return 1;

                if ((_board[threeChoices[1]] == piece) && (_board[threeChoices[0]] == XorO.None))
                    return 0;
            }

            return -1;
        }

        /// <summary>
        /// Check if computer should play next
        /// </summary>
        internal void CheckIfComputerPlay()
        {
            if (TwoPlayer) return;
            if (GameOver) return;
            if (!IsComputersTurn) return;

            Thread.Sleep(200);  // add delay to computer response;
            LetComputerPlayTurn();
        }

        /// <summary>
        /// Check for best blocking move
        /// </summary>
        /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
        /// <remarks>
        /// 0 1 2
        /// 3 4 5
        /// 6 7 8
        /// </remarks>
        internal int CheckForBestBlockingMove(XorO computerChoice)
        {
            // pick corner edge position if available
            foreach (var threeInARow in _choiceHeirarchy)
            {
                var open = CheckBestChoice(threeInARow, computerChoice);
                if (open >= 0)
                    return threeInARow[open];
            }

            return -1;
        }

        /// <summary>
        /// Check for best blocking move
        /// </summary>
        /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
        /// <remarks>
        /// 0 1 2
        /// 3 4 5
        /// 6 7 8
        /// </remarks>
        internal int CheckForSpecialBlockingMove(XorO computerChoice, XorO opponentChoice)
        {
            if (_board[4] != computerChoice)
                return -1;

            if ((_board[0] == opponentChoice && _board[8] == opponentChoice)
                || _board[2] == opponentChoice && _board[6] == opponentChoice)
            {
                if (_board[1] == XorO.None && _board[7] == XorO.None)
                    return 1;

                if (_board[3] == XorO.None && _board[5] == XorO.None)
                    return 3;
            }

            if ((_board[1] == opponentChoice || _board[2] == opponentChoice)
                && (_board[3] == opponentChoice || _board[6] == opponentChoice)
                && _board[0] == XorO.None)
            {
                return 0;
            }

            if ((_board[1] == opponentChoice || _board[0] == opponentChoice)
                && (_board[5] == opponentChoice || _board[8] == opponentChoice)
                && _board[2] == XorO.None)
            {
                return 2;
            }

            if ((_board[5] == opponentChoice || _board[2] == opponentChoice)
                && (_board[7] == opponentChoice || _board[6] == opponentChoice)
                && _board[8] == XorO.None)
            {
                return 8;
            }

            if ((_board[7] == opponentChoice || _board[8] == opponentChoice)
                && (_board[3] == opponentChoice || _board[0] == opponentChoice)
                && _board[6] == XorO.None)
            {
                return 6;
            }

            return -1;
        }

        /// <summary>
        /// Picks a random corner to play in.
        /// </summary>
        /// <returns>If found, returns an integer value representing the square; otherwise, -1</returns>
        /// <remarks>
        /// 0 1 2
        /// 3 4 5
        /// 6 7 8
        /// </remarks>
        internal int PickRandomCorner()
        {
            if ((LeftTopChoice == XorO.None)
                || (RightTopChoice == XorO.None)
                || (LeftBottomChoice == XorO.None)
                || (RightBottomChoice == XorO.None))
            {
                int index = Random.Shared.Next(4);  // randomly pick between the four choices

                int open = -1;
                while (open == -1)
                {
                    if (index == 0 && LeftTopChoice == XorO.None) open = 0;
                    if (index <= 1 && RightTopChoice == XorO.None) open = 2;
                    if (index <= 2 && LeftBottomChoice == XorO.None) open = 6;
                    if (index <= 3 && RightBottomChoice == XorO.None) open = 8;
                    if (open == -1) index = 0;
                }
                return open;
            }

            return -1;
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
                if ((_board[threeInARow[0]] != XorO.None) && (_board[threeInARow[0]] == _board[threeInARow[1]] && _board[threeInARow[0]] == _board[threeInARow[2]]))
                {
                    WinningSelection = i;
                    UpdateWinningLine();
                    HasWinner = true;
                    GameOver = true;

                    Instructions = $"'{(_board[threeInARow[0]] == XorO.X_Visible ? "X" : "O")}' Wins";
                    break;
                }
                i++;
            }

            if (!GameOver)
            {
                //var count = _board.Count(o => o == XorO.None);

                //if (count <= 1)
                //{
                    var isTie = _board.All(o => o != XorO.None);
                    if (isTie)
                    {
                        // all possible moved made, so game is a tie.
                        GameOver = true;
                        Instructions = "Tie";
                    }
                    //else
                    //{
                    //    // one move left, if it is not a possible winning move end early.
                    //    bool canWin = false;

                    //    var _board2 = new XorO[_board.Length];
                    //    Array.Copy(_board, _board2, _board2.Length);

                    //    for (int j = 0; j < _board2.Length; j++)
                    //    {
                    //        if (_board2[j] == XorO.None)
                    //        {
                    //            _board2[j] = _isX ? XorO.X_Visible : XorO.O_Visible;
                    //            break;
                    //        }
                    //    }

                    //    foreach (var threeInARow in _winningCombinations)
                    //    {
                    //        if ((_board2[threeInARow[0]] == _board2[threeInARow[1]] && _board2[threeInARow[0]] == _board2[threeInARow[2]]))
                    //        {
                    //            canWin = true;
                    //            break;
                    //        }
                    //    }

                    //    if (!canWin)
                    //    {
                    //        for (int j = 0; j < _board.Length; j++)
                    //        {
                    //            if (_board[j] == XorO.None)
                    //            {
                    //                Play(j);
                    //                break;
                    //            }
                    //        }

                    //        GameOver = true;
                    //        Instructions = "Tie";
                    //    }

                    //}

                //}
            }
        }

        /// <summary>
        /// Used by the computer to identify that there is one play away from winning.
        /// </summary>
        /// <param name="threeInARow">A winning combination of moves.</param>
        /// <param name="piece">Indicates if the game piece is an X or O.</param>
        /// <returns>An integer representing the winning move into the array of the three choices; otherwise, -1 to indicate a winning choice was not found.</returns>
        /// <remarks>
        ///  0 | 1 | 2
        ///  ---------
        ///  3 | 4 | 5
        ///  ---------
        ///  6 | 7 | 8
        /// </remarks>
        internal int CheckShouldPlay(int[] threeInARow, XorO piece)
        {
            if ((_board[threeInARow[0]] == XorO.None) && (_board[threeInARow[1]] == piece) && (_board[threeInARow[2]] == piece))
                return 0;

            if ((_board[threeInARow[0]] == piece) && (_board[threeInARow[1]] == XorO.None) && (_board[threeInARow[2]] == piece))
                return 1;

            if ((_board[threeInARow[0]] == piece) && (_board[threeInARow[1]] == piece) && (_board[threeInARow[2]] == XorO.None))
                return 2;

            return -1;
        }

        /// <summary>
        /// Play as a the computer
        /// </summary>
        internal void LetComputerPlayTurn()
        {
            int open;

            var computerChoice = _isX ? XorO.X_Visible : XorO.O_Visible;
            var opponentChoice = _isX ? XorO.O_Visible : XorO.X_Visible;


            // TODO this should also randomly pick a corner square if the computer goes first.
            // always pick center if open
            if (CenterMiddleChoice == XorO.None)
            {
                Play(4);
                return;
            }

            // check for winning move
            foreach (var threeInARow in _winningCombinations)
            {
                open = CheckShouldPlay(threeInARow, computerChoice);
                if (open >= 0)
                {
                    Play(threeInARow[open]);
                    return;
                }
            }

            // check to make sure opponent doesn't win in next move
            foreach (var threeInARow in _winningCombinations)
            {
                open = CheckShouldPlay(threeInARow, opponentChoice);
                if (open >= 0)
                {
                    Play(threeInARow[open]);
                    return;
                }
            }

            // TODO: check for special condition of two opposite corners selected.
            open = CheckForSpecialBlockingMove(computerChoice, opponentChoice);
            if (open >= 0)
            {
                Play(open);
                return;
            }

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
                    Play(i);
                    return;
                }
            }

        }

        /// <summary>
        /// Handles the selection of a square
        /// </summary>
        /// <param name="currentChoice">The current value of the square</param>
        /// <returns>The new value of the square.</returns>
        internal XorO PickSquare(XorO currentChoice)
        {
            if (GameOver) return currentChoice;
            if (currentChoice != XorO.None) return currentChoice;

            _isX = !_isX;
            UpdateInstructions();

            return _isX ? XorO.O_Visible : XorO.X_Visible;
        }

        /// <summary>
        /// Sets the square based on the computer's choice.
        /// </summary>
        /// <param name="choice">An integer that represents a tic-tac-toe square position.</param>
        /// <remarks>
        ///  0 | 1 | 2
        ///  ---------
        ///  3 | 4 | 5
        ///  ---------
        ///  6 | 7 | 8
        /// </remarks>
        internal void Play(int choice)
        {

#if DEBUG
            if (_board[choice] != XorO.None)
            {
                Debug.WriteLine("Invalid Choice");
            }
#endif

            switch (choice)
            {
                case 0:
                    {
                        LeftTopChoice = PickSquare(LeftTopChoice);
                        break;
                    }
                case 1:
                    {
                        CenterTopChoice = PickSquare(CenterTopChoice);
                        break;
                    }
                case 2:
                    {
                        RightTopChoice = PickSquare(RightTopChoice);
                        break;
                    }
                case 3:
                    {
                        LeftMiddleChoice = PickSquare(LeftMiddleChoice);
                        break;
                    }
                case 4:
                    {
                        CenterMiddleChoice = PickSquare(CenterMiddleChoice);
                        break;
                    }
                case 5:
                    {
                        RightMiddleChoice = PickSquare(RightMiddleChoice);
                        break;
                    }
                case 6:
                    {
                        LeftBottomChoice = PickSquare(LeftBottomChoice);
                        break;
                    }
                case 7:
                    {
                        CenterBottomChoice = PickSquare(CenterBottomChoice);
                        break;
                    }
                case 8:
                    {
                        RightBottomChoice = PickSquare(RightBottomChoice);
                        break;
                    }
            }
        }

        /// <summary>
        /// Handle the for resize event to re-calculate the size of the tic-tac-toe board
        /// </summary>
        /// <param name="width">Width of the form.</param>
        /// <param name="height">Height of the form.</param>
        internal void SizeChanged(double width, double height)
        {
            TopRowHeight = height > 500 ? 70.0 : 0.0;
            GridSize = Math.Min(width - 24, height - 50.0 - TopRowHeight);
            UpdateWinningLine();
        }

        /// <summary>
        /// Update the instructions for the next step.
        /// </summary>
        internal void UpdateInstructions()
        {
            var turn = _isX ? "X" : "O";
            Instructions = $"'{turn}' goes next.";
        }

        /// <summary>
        /// Update the position of the winning line.
        /// </summary>
        internal void UpdateWinningLine()
        {
            if (WinningSelection == -1) return;

            var choiceSize = GridSize / 3;

            switch (WinningSelection)
            {
                case 0:
                    {
                        WinningX1 = 0.0;
                        WinningX2 = GridSize;
                        WinningY1 = choiceSize * 0.5;
                        WinningY2 = choiceSize * 0.5;
                        break;
                    }
                case 1:
                    {
                        WinningX1 = 0.0;
                        WinningX2 = GridSize;
                        WinningY1 = choiceSize * 1.5;
                        WinningY2 = choiceSize * 1.5;
                        break;
                    }
                case 2:
                    {
                        WinningX1 = 0.0;
                        WinningX2 = GridSize;
                        WinningY1 = choiceSize * 2.5;
                        WinningY2 = choiceSize * 2.5;
                        break;
                    }
                case 3:
                    {
                        WinningX1 = choiceSize * 0.5;
                        WinningX2 = choiceSize * 0.5;
                        WinningY1 = 0.0;
                        WinningY2 = GridSize;
                        break;
                    }
                case 4:
                    {
                        WinningX1 = choiceSize * 1.5;
                        WinningX2 = choiceSize * 1.5;
                        WinningY1 = 0.0;
                        WinningY2 = GridSize;
                        break;
                    }
                case 5:
                    {
                        WinningX1 = choiceSize * 2.5;
                        WinningX2 = choiceSize * 2.5;
                        WinningY1 = 0.0;
                        WinningY2 = GridSize;
                        break;
                    }
                case 6:
                    {
                        WinningX1 = 0.0;
                        WinningX2 = GridSize;
                        WinningY1 = 0.0;
                        WinningY2 = GridSize;
                        break;
                    }
                case 7:
                    {
                        WinningX1 = GridSize;
                        WinningX2 = 0.0;
                        WinningY1 = 0.0;
                        WinningY2 = GridSize;
                        break;
                    }

            }
        }

        #endregion Methods

    }
}
