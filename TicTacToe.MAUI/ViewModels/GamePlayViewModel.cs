using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Web;
using TicTacToe.Business.Business;
using TicTacToe.Enums;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This view model is used to handle game play.
    /// This includes the decision made by the computer.
    /// </summary>
    public partial class GamePlayViewModel : ViewModelSupport, IQueryAttributable, IGamePlayViewModel
    {

        #region Fields

        internal readonly List<SquarePosition[]> _choiceHeirarchy = new()
        {
            new[] { SquarePosition.LeftTop, SquarePosition.RightTop, SquarePosition.LeftBottom },
            new[] { SquarePosition.RightTop, SquarePosition.RightBottom, SquarePosition.LeftBottom },
            new[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.LeftMiddle },
            new[] { SquarePosition.CenterTop, SquarePosition.RightTop, SquarePosition.RightMiddle },
            new[] { SquarePosition.RightMiddle, SquarePosition.RightBottom, SquarePosition.CenterBottom },
            new[] { SquarePosition.LeftMiddle, SquarePosition.LeftBottom, SquarePosition.CenterBottom }
        };

        internal readonly List<SquarePosition[]> _winningCombinations = new()
        {
            new[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop },
            new[] { SquarePosition.LeftMiddle, SquarePosition.CenterMiddle, SquarePosition.RightMiddle },
            new[] { SquarePosition.LeftBottom, SquarePosition.CenterBottom, SquarePosition.RightBottom },
            new[] { SquarePosition.LeftTop, SquarePosition.LeftMiddle, SquarePosition.LeftBottom },
            new[] { SquarePosition.CenterTop, SquarePosition.CenterMiddle, SquarePosition.CenterBottom },
            new[] { SquarePosition.RightTop, SquarePosition.RightMiddle, SquarePosition.RightBottom },
            new[] { SquarePosition.LeftTop, SquarePosition.CenterMiddle, SquarePosition.RightBottom },
            new[] { SquarePosition.RightTop, SquarePosition.CenterMiddle, SquarePosition.LeftBottom }
        };

        private GamePlay _gamePlay;

        #endregion Fields

        #region Constructor

        public GamePlayViewModel()
        {
            _gamePlay = new GamePlay(this);
        }

        #endregion Constructor

        #region IQueryAttributable

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

        #endregion IQueryAttributable

        #region Properties

        /// <summary>
        /// Make the game play object available internally for unit testing
        /// </summary>
        internal GamePlay GamePlay => _gamePlay;

        #endregion Properties

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
        /// [7] Handles the click event for the center bottom square
        /// </summary>
        [RelayCommand]
        public void CenterBottomClick() { CenterBottomChoice = _gamePlay.PickSquare(CenterBottomChoice); }

        /// <summary>
        /// [4] Handles the click event for the center square
        /// </summary>
        [RelayCommand]
        public void CenterMiddleClick() { CenterMiddleChoice = _gamePlay.PickSquare(CenterMiddleChoice); }

        /// <summary>
        /// [1] Handles the click event for the center top square
        /// </summary>
        [RelayCommand]
        public void CenterTopClick() { CenterTopChoice = _gamePlay.PickSquare(CenterTopChoice); }

        /// <summary>
        /// [6] Handles the click event for the left side bottom square
        /// </summary>
        [RelayCommand]
        public void LeftBottomClick() { LeftBottomChoice = _gamePlay.PickSquare(LeftBottomChoice); }

        /// <summary>
        /// [3] Handles the click event for the left side middle square
        /// </summary>
        [RelayCommand]
        public void LeftMiddleClick() { LeftMiddleChoice = _gamePlay.PickSquare(LeftMiddleChoice); }

        /// <summary>
        /// [0] Handles the click event for the left side top square
        /// </summary>
        [RelayCommand]
        public void LeftTopClick() { LeftTopChoice = _gamePlay.PickSquare(LeftTopChoice); }
        /// <summary>
        /// [8] Handles the click event for the right side bottom square
        /// </summary>
        [RelayCommand]
        public void RightBottomClick() { RightBottomChoice = _gamePlay.PickSquare(RightBottomChoice); }

        /// <summary>
        /// [5] Handles the click event for the right side middle square
        /// </summary>
        [RelayCommand]
        public void RightMiddleClick() { RightMiddleChoice = _gamePlay.PickSquare(RightMiddleChoice); }

        /// <summary>
        /// [2] Handles the click event for the right side top square
        /// </summary>
        [RelayCommand]
        public void RightTopClick() { RightTopChoice = _gamePlay.PickSquare(RightTopChoice); }

        #endregion Tic-Tac-Toe Square Relay Commands

        #region Auto Relay Commands from Methods

        /// <summary>
        /// PlayAgainClick to default values
        /// </summary>
        [RelayCommand]
        public void PlayAgainClick()
        {
            _gamePlay.IsX = false;
            HasWinner = false;
            GameOver = false;
            WinningSelection = -1;
            _gamePlay.ComputerChoice = ComputerStarts ? XorO.O_Visible : XorO.X_Visible;
            for (int i = 0; i < _gamePlay.Board.Count(); i++)
            {
                _gamePlay.Board[i] = XorO.None;
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

            _gamePlay.UpdateInstructions();

            CheckIfComputerCanPlay();
        }

        #endregion Auto Relay Commands from Methods

        #region Tic-Tac-Toe Square Properties

        /// <summary>
        /// [7] The current value of the center bottom square
        /// </summary>
        public XorO CenterBottomChoice
        {
            get => _gamePlay.Board[7];
            set
            {
                if (SetProperty(ref _gamePlay.Board[7], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [4] The current value of the center square
        /// </summary>
        public XorO CenterMiddleChoice
        {
            get => _gamePlay.Board[4];
            set
            {
                if (SetProperty(ref _gamePlay.Board[4], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [1] The current value of the center top square
        /// </summary>
        public XorO CenterTopChoice
        {
            get => _gamePlay.Board[1];
            set
            {
                if (SetProperty(ref _gamePlay.Board[1], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [6] The current value of the left side bottom square
        /// </summary>
        public XorO LeftBottomChoice
        {
            get => _gamePlay.Board[6];
            set
            {
                if (SetProperty(ref _gamePlay.Board[6], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [3] The current value of the left side middle square
        /// </summary>
        public XorO LeftMiddleChoice
        {
            get => _gamePlay.Board[3];
            set
            {
                if (SetProperty(ref _gamePlay.Board[3], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [0] The current value of the left side top square
        /// </summary>
        public XorO LeftTopChoice
        {
            get => _gamePlay.Board[0];
            set
            {
                if (SetProperty(ref _gamePlay.Board[0], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [8] The current value of the right side bottom square
        /// </summary>
        public XorO RightBottomChoice
        {
            get => _gamePlay.Board[8];
            set
            {
                if (SetProperty(ref _gamePlay.Board[8], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [5] The current value of the right side middle square
        /// </summary>
        public XorO RightMiddleChoice
        {
            get => _gamePlay.Board[5];
            set
            {
                if (SetProperty(ref _gamePlay.Board[5], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// [2] The current value of the right side top square
        /// </summary>
        public XorO RightTopChoice
        {
            get => _gamePlay.Board[2];
            set
            {
                if (SetProperty(ref _gamePlay.Board[2], value))
                    UpdatePlay();
            }
        }

        /// <summary>
        /// Update the game board after a square has been picked.
        /// </summary>
        private void UpdatePlay()
        {
            _gamePlay.CheckIfWinnerOrDraw();
            CheckIfComputerCanPlay();
        }

        /// <summary>
        /// Checks whether the computer is able to play its turn and, if so, initiates the computer's move.
        /// </summary>
        /// <remarks>This method introduces a short delay before allowing the computer to play, which can
        /// be used to simulate thinking time or improve user experience in turn-based games. Intended for internal use
        /// within the game loop or turn management logic.</remarks>
        private void CheckIfComputerCanPlay()
        {
            if (_gamePlay.CheckIfComputerPlay())
            {
                Thread.Sleep(200);  // add delay to computer response;
                _gamePlay.LetComputerPlayTurn();
            }
        }

        #endregion Tic-Tac-Toe Square Properties

        #region Properties

        /// <summary>
        /// Update the position of the winning line.
        /// </summary>
        public void UpdateWinningLine()
        {
            if (_gamePlay.WinningSelection == -1) return;

            var choiceSize = GridSize / 3;

            switch (_gamePlay.WinningSelection)
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

        #endregion Properties

        #region UI Properties

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

        #endregion UI Properties

    }
}
