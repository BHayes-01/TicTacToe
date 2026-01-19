using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Web;
using TicTacToe.Business.Business;
using TicTacToe.Enums;

namespace TicTacToe.ViewModels;

/// <summary>
/// This view model is used to handle game play.
/// This includes the decision made by the computer.
/// </summary>
public partial class GamePlayViewModel : ViewModelSupport, IQueryAttributable, IGamePlayViewModel, IDisposable
{

    #region Fields

    private IGamePlay _gamePlay;

    #endregion Fields

    #region Constructor

    public GamePlayViewModel(IGamePlay gamePlay)
    {
        _gamePlay = gamePlay;
        OnPropertyChanged(nameof(GamePlay));
        GamePlay.PropertyChanged += GamePlay_PropertyChanged;
        GamePlay.ComputerPlayed += GamePlay_ComputerPlayed;
    }

    ~GamePlayViewModel()
    {
        DisposeEvents();
    }

    internal GamePlayViewModel()
    {
        _gamePlay = new GamePlay();
        OnPropertyChanged(nameof(GamePlay));
        GamePlay.PropertyChanged += GamePlay_PropertyChanged;
        GamePlay.ComputerPlayed += GamePlay_ComputerPlayed;
    }

    public void Dispose()
    {
        DisposeEvents();
    }

    private void DisposeEvents()
    {
        // Unregister to prevent memory leaks
        if (GamePlay is null) return;

        GamePlay.PropertyChanged -= GamePlay_PropertyChanged;
        GamePlay.ComputerPlayed -= GamePlay_ComputerPlayed;
        _gamePlay = null;
    }

    #endregion Constructor

    #region IQueryAttributable

    /// <summary>
    /// This method is supposed to get the parameter arguments that are passed in from the main start page.
    /// </summary>
    /// <param name="query"></param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        PlayAgainClick();
    }

    private static bool TryGetBool(IDictionary<string, object> query, string key, out bool value)
    {
        value = false;

        if (!query.TryGetValue(key, out var raw) || raw is null)
            return false;

        var decoded = HttpUtility.UrlDecode(raw.ToString());
        return bool.TryParse(decoded, out value);
    }

    #endregion IQueryAttributable

    #region Properties

    /// <summary>
    /// Make the game play object available internally for unit testing
    /// </summary>
    public IGamePlay GamePlay
    {
        get => _gamePlay;
    }

    /// <summary>
    /// Handle the event when the computer has made its choice
    /// </summary>
    /// <param name="sender">Reference to the GamePlay class</param>
    /// <param name="e">The event argument that contains the square position on the choice made.</param>
    private void GamePlay_ComputerPlayed(object sender, ComputerChoiceEventArgs e)
    {
        switch (e.Square)
        {
            case SquarePosition.LeftTop:
                {
                    LeftTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterTop:
                {
                    CenterTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightTop:
                {
                    RightTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.LeftMiddle:
                {
                    LeftMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterMiddle:
                {
                    CenterMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightMiddle:
                {
                    RightMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.LeftBottom:
                {
                    LeftBottomChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterBottom:
                {
                    CenterBottomChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightBottom:
                {
                    RightBottomChoice = e.Choice;
                    break;
                }

            case SquarePosition.Invalid:
                throw new ArgumentException("Invalid square position selected");

        }
    }

    private void GamePlay_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {

            case nameof(IGamePlay.ComputerStarts):
                RunOnMainThread(() => OnPropertyChanged(e.PropertyName));
                break;

            case nameof(IGamePlay.GameOver):
                RunOnMainThread(() => OnPropertyChanged(e.PropertyName));
                break;

            case nameof(IGamePlay.HasWinner):
                RunOnMainThread(() => UpdateWinningLine());
                break;

            case nameof(IGamePlay.Instructions):
                RunOnMainThread(() => OnPropertyChanged(e.PropertyName));
                break;

            case nameof(IGamePlay.IsX):
                RunOnMainThread(() => OnPropertyChanged(e.PropertyName));
                break;

            case nameof(IGamePlay.TwoPlayer):
                RunOnMainThread(() => OnPropertyChanged(e.PropertyName));
                break;

        }
    }

    #endregion Properties

    #region Auto Properties From Fields

    /// <summary>
    /// The size of the tic-tac-toe board, the width and height needs to be the same
    /// </summary>
    [ObservableProperty]
    public partial double GridSize { get; set; }

    /// <summary>
    /// Used to hide the Title if the height is too small
    /// </summary>
    [ObservableProperty]
    public partial double TopRowHeight { get; set; }

    /// <summary>
    /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
    /// </summary>
    [ObservableProperty]
    public partial double WinningX1 { get; set; }

    /// <summary>
    /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
    /// </summary>
    [ObservableProperty]
    public partial double WinningX2 { get; set; }

    /// <summary>
    /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
    /// </summary>
    [ObservableProperty]
    public partial double WinningY1 { get; set; }

    /// <summary>
    /// Handles the location of the winning line (X1, Y1) - (X2 - Y2).
    /// </summary>
    [ObservableProperty]
    public partial double WinningY2 { get; set; }

    #endregion Auto Properties From Fields

    #region Tic-Tac-Toe Square Auto Generated Relay Commands

    /// <summary>
    /// [7] Handles the click event for the center bottom square
    /// </summary>
    [RelayCommand]
    public void CenterBottomClick()
    {
        CenterBottomChoice = IsSquareXorO();
    }

    /// <summary>
    /// [4] Handles the click event for the center square
    /// </summary>
    [RelayCommand]
    public void CenterMiddleClick()
    {
        CenterMiddleChoice = IsSquareXorO();
    }

    /// <summary>
    /// [1] Handles the click event for the center top square
    /// </summary>
    [RelayCommand]
    public void CenterTopClick()
    {
        CenterTopChoice = IsSquareXorO();
    }

    /// <summary>
    /// [6] Handles the click event for the left side bottom square
    /// </summary>
    [RelayCommand]
    public void LeftBottomClick()
    {
        LeftBottomChoice = IsSquareXorO();
    }

    /// <summary>
    /// [3] Handles the click event for the left side middle square
    /// </summary>
    [RelayCommand]
    public void LeftMiddleClick()
    {
        LeftMiddleChoice = IsSquareXorO();
    }

    /// <summary>
    /// [0] Handles the click event for the left side top square
    /// </summary>
    [RelayCommand]
    public void LeftTopClick()
    {
        LeftTopChoice = IsSquareXorO();
    }

    /// <summary>
    /// [8] Handles the click event for the right side bottom square
    /// </summary>
    [RelayCommand]
    public void RightBottomClick()
    {
        RightBottomChoice = IsSquareXorO();
    }

    /// <summary>
    /// [5] Handles the click event for the right side middle square
    /// </summary>
    [RelayCommand]
    public void RightMiddleClick()
    {
        RightMiddleChoice = IsSquareXorO();
    }

    /// <summary>
    /// [2] Handles the click event for the right side top square
    /// </summary>
    [RelayCommand]
    public void RightTopClick()
    {
        RightTopChoice = IsSquareXorO();
    }

    private XorO IsSquareXorO()
    {
        return GamePlay.IsX ? XorO.X_Visible : XorO.O_Visible;
    }

    #endregion Tic-Tac-Toe Square Relay Commands

    #region Auto Relay Commands from Methods

    /// <summary>
    /// PlayAgainClick to default values
    /// </summary>
    [RelayCommand]
    public void PlayAgainClick()
    {
        GamePlay.PlayAgain();

        RefreshBoard();
    }

    #endregion Auto Relay Commands from Methods

    #region Tic-Tac-Toe Square Properties

    /// <summary>
    /// [7] The current value of the center bottom square
    /// </summary>
    public XorO CenterBottomChoice
    {
        get => GamePlay.CenterBottomChoice;
        set
        {
            GamePlay.CenterBottomChoice = value;
            OnPropertyChanged(nameof(CenterBottomChoice));
        }
    }

    /// <summary>
    /// [4] The current value of the center square
    /// </summary>
    public XorO CenterMiddleChoice
    {
        get => GamePlay.CenterMiddleChoice;
        set
        {
            GamePlay.CenterMiddleChoice = value;
            OnPropertyChanged(nameof(CenterMiddleChoice));
        }
    }

    /// <summary>
    /// [1] The current value of the center top square
    /// </summary>
    public XorO CenterTopChoice
    {
        get => GamePlay.CenterTopChoice;
        set
        {
            GamePlay.CenterTopChoice = value;
            OnPropertyChanged(nameof(CenterTopChoice));
        }
    }

    /// <summary>
    /// [6] The current value of the left side bottom square
    /// </summary>
    public XorO LeftBottomChoice
    {
        get => GamePlay.LeftBottomChoice;
        set
        {
            GamePlay.LeftBottomChoice = value;
            OnPropertyChanged(nameof(LeftBottomChoice));
        }
    }

    /// <summary>
    /// [3] The current value of the left side middle square
    /// </summary>
    public XorO LeftMiddleChoice
    {
        get => GamePlay.LeftMiddleChoice;
        set
        {
            GamePlay.LeftMiddleChoice = value;
            OnPropertyChanged(nameof(LeftMiddleChoice));
        }
    }

    /// <summary>
    /// [0] The current value of the left side top square
    /// </summary>
    public XorO LeftTopChoice
    {
        get => GamePlay.LeftTopChoice;
        set
        {
            GamePlay.LeftTopChoice = value;
            OnPropertyChanged(nameof(LeftTopChoice));
        }
    }

    /// <summary>
    /// [8] The current value of the right side bottom square
    /// </summary>
    public XorO RightBottomChoice
    {
        get => GamePlay.RightBottomChoice;
        set
        {
            GamePlay.RightBottomChoice = value;
            OnPropertyChanged(nameof(RightBottomChoice));
        }
    }

    /// <summary>
    /// [5] The current value of the right side middle square
    /// </summary>
    public XorO RightMiddleChoice
    {
        get => GamePlay.RightMiddleChoice;
        set
        {
            GamePlay.RightMiddleChoice = value;
            OnPropertyChanged(nameof(RightMiddleChoice));
        }
    }

    /// <summary>
    /// [2] The current value of the right side top square
    /// </summary>
    public XorO RightTopChoice
    {
        get => GamePlay.RightTopChoice;
        set
        {
            GamePlay.RightTopChoice = value;
            OnPropertyChanged(nameof(RightTopChoice));
        }
    }

    #endregion Tic-Tac-Toe Square Properties

    #region Methods

    /// <summary>
    /// Runs the action on the main thread.
    /// </summary>
    /// <param name="action">The method to run.</param>
    public void RunOnMainThread(Action action)
    {
        bool isMainThread = false;

        try
        {
            isMainThread = MainThread.IsMainThread;
        }
        catch
        {
            // running in unit test mode
            isMainThread = true;
        }

        if (!isMainThread)
            MainThread.BeginInvokeOnMainThread(action);
        else
            action();
    }

    /// <summary>
    /// Update the position of the winning line.
    /// </summary>
    public void UpdateWinningLine()
    {
        if (GamePlay.WinningSelection == -1) return;

        var choiceSize = GridSize / 3;

        switch (GamePlay.WinningSelection)
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

    private void RefreshBoard()
    {
        OnPropertyChanged(nameof(LeftTopChoice));
        OnPropertyChanged(nameof(CenterTopChoice));
        OnPropertyChanged(nameof(RightTopChoice));
        OnPropertyChanged(nameof(LeftMiddleChoice));
        OnPropertyChanged(nameof(CenterMiddleChoice));
        OnPropertyChanged(nameof(RightMiddleChoice));
        OnPropertyChanged(nameof(LeftBottomChoice));
        OnPropertyChanged(nameof(CenterBottomChoice));
        OnPropertyChanged(nameof(RightBottomChoice));

    }

    #endregion Methods

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
