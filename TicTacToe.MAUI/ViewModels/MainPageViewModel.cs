using CommunityToolkit.Mvvm.Input;
using TicTacToe.Business.Business;
using TicTacToe.Views;

namespace TicTacToe.ViewModels;

/// <summary>
/// This is the main page or start page
/// </summary>
public partial class MainPageViewModel(IGamePlay gamePlay) : ViewModelSupport
{
    
    #region Auto Properties from Fields

    /// <summary>
    /// Indicates if the computer starts
    /// </summary>
    public bool TwoPlayer 
    { 
        get => gamePlay.TwoPlayer;
        set
        {
            if (gamePlay.TwoPlayer != value)
            {
                gamePlay.TwoPlayer = value;
                OnPropertyChanged(nameof(TwoPlayer));
            }
        }
    }

    /// <summary>
    /// Indicates if the game has two players; otherwise, one player.
    /// </summary>
    public bool ComputerStarts 
    {
        get => gamePlay.ComputerStarts;
        set
        {
            if (gamePlay.ComputerStarts != value)
            {
                gamePlay.ComputerStarts = value;
                OnPropertyChanged(nameof(ComputerStarts));
            }
        }
    }

    /// <summary>
    /// Make the game play object available internally for unit testing
    /// </summary>
    public IGamePlay GamePlay => gamePlay;

    #endregion Fields
    
    #region Auto Relay Commands from Methods

    /// <summary>
    /// Navigate to the about view
    /// </summary>
    [RelayCommand]
    public async Task AboutClick()
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(AboutView)}");
        }
        catch
        {
            throw new InvalidOperationException($"Unable to resolve type {nameof(AboutView)}");
        }
    }

    /// <summary>
    /// Navigate to the game play view
    /// </summary>
    [RelayCommand]
    public async Task StartClick()
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(GamePlayView)}");
        }
        catch
        {
            throw new InvalidOperationException($"Unable to resolve type {nameof(GamePlayView)}");
        }
    }

    #endregion Relay Commands

}
