using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TicTacToe.Views;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This is the main page or start page
    /// </summary>
    public partial class MainPageViewModel : ObservableObject
    {

        #region Auto Properties from Fields

        /// <summary>
        /// Indicates if the computer starts
        /// </summary>
        [ObservableProperty]
        private bool _twoPlayer;

        /// <summary>
        /// Indicates if the game has two players; otherwise, one player.
        /// </summary>
        [ObservableProperty]
        private bool _computerStarts;

        #endregion Fields
        
        #region Auto Relay Commands from Methods

        /// <summary>
        /// Navigate to the about view
        /// </summary>
        [RelayCommand]
        public async void AboutClick()
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
        public async void StartClick()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(GamePlayView)}?TwoPlayer={TwoPlayer}&ComputerStarts={ComputerStarts}");
            }
            catch
            {
                throw new InvalidOperationException($"Unable to resolve type {nameof(GamePlayView)}");
            }
        }

        #endregion Relay Commands



    }
}
