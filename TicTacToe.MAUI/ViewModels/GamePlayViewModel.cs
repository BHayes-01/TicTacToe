using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Web;
using TicTacToe.Business.Business;
using TicTacToe.Enums;

namespace TicTacToe.ViewModels;

/// <summary>
/// This view model is used to handle game play.
/// This includes the decision made by the computer.
/// </summary>
public partial class GamePlayViewModel : ViewModelSupport, IQueryAttributable, IGamePlayViewModel
{

    #region Fields

    private GamePlay _gamePlay;

    #endregion Fields

    #region IQueryAttributable

    /// <summary>
    /// This method is supposed to get the parameter arguments that are passed in from the main start page.
    /// </summary>
    /// <param name="query"></param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // get the value of Two Player here.  
        if (TryGetBool(query, nameof(GamePlay.TwoPlayer), out var twoPlayer))
            GamePlay.TwoPlayer = twoPlayer;

        // get the value of Computer Starts here.
        if (TryGetBool(query, nameof(GamePlay.ComputerStarts), out var computerStarts))
            GamePlay.ComputerStarts = computerStarts;

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
    public GamePlay GamePlay
    {
        get
        {
            if (_gamePlay is null)
            {
                _gamePlay = new GamePlay(this);
                OnPropertyChanged(nameof(GamePlay));
            }
            return _gamePlay;
        }
        set => _gamePlay = value;
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
        var value = SetSquare();
        if (CenterBottomChoice != value)
            CenterBottomChoice = value;
    }

    /// <summary>
    /// [4] Handles the click event for the center square
    /// </summary>
    [RelayCommand]
    public void CenterMiddleClick()
    {
        var value = SetSquare();
        if (CenterMiddleChoice != value)
            CenterMiddleChoice = value;
    }

    /// <summary>
    /// [1] Handles the click event for the center top square
    /// </summary>
    [RelayCommand]
    public void CenterTopClick()
    {
        var value = SetSquare();
        if (CenterTopChoice != value)
            CenterTopChoice = value;
    }

    /// <summary>
    /// [6] Handles the click event for the left side bottom square
    /// </summary>
    [RelayCommand]
    public void LeftBottomClick()
    {
        var value = SetSquare();
        if (LeftBottomChoice != value)
            LeftBottomChoice = value;
    }

    /// <summary>
    /// [3] Handles the click event for the left side middle square
    /// </summary>
    [RelayCommand]
    public void LeftMiddleClick()
    {
        var value = SetSquare();
        if (LeftMiddleChoice != value)
            LeftMiddleChoice = value;
    }

    /// <summary>
    /// [0] Handles the click event for the left side top square
    /// </summary>
    [RelayCommand]
    public void LeftTopClick()
    {
        var value = SetSquare();
        if (LeftTopChoice != value)
            LeftTopChoice = value;
    }

    /// <summary>
    /// [8] Handles the click event for the right side bottom square
    /// </summary>
    [RelayCommand]
    public void RightBottomClick()
    {
        var value = SetSquare();
        if (RightBottomChoice != value)
            RightBottomChoice = value;
    }

    /// <summary>
    /// [5] Handles the click event for the right side middle square
    /// </summary>
    [RelayCommand]
    public void RightMiddleClick()
    {
        var value = SetSquare();
        if (RightMiddleChoice != value)
            RightMiddleChoice = value;
    }

    /// <summary>
    /// [2] Handles the click event for the right side top square
    /// </summary>
    [RelayCommand]
    public void RightTopClick()
    {
        var value = SetSquare();
        if (RightTopChoice != value)
            RightTopChoice = value;
    }

    private XorO SetSquare()
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

        if (isMainThread)
            action();
        else
            MainThread.BeginInvokeOnMainThread(action);
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
