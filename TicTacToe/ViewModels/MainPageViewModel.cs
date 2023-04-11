using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TicTacToe.Views;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This is the main page or start page
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {

        #region Fields

        private bool _twoPlayer;
        private bool _computerStarts;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Constructor for the main page
        /// </summary>
        public MainPageViewModel()
        {
            AboutClick = new RelayCommand(NavigateToAboutView);
            StartClick = new RelayCommand(NavigateToGamePlayView);
        }

        #endregion Constructor

        #region Relay Commands

        /// <summary>
        /// Handles the button "About" click.
        /// </summary>
        public ICommand AboutClick { private set; get; }

        /// <summary>
        /// Handles the button "Start" click.
        /// </summary>
        public ICommand StartClick { private set; get; }

        #endregion Relay Commands

        #region Properties

        /// <summary>
        /// Indicates if the computer starts
        /// </summary>
        public bool ComputerStarts
        {
            get => _computerStarts;
            set => SetProperty(ref _computerStarts, value);
        }

        /// <summary>
        /// Indicates if the game has two players; otherwise, one player.
        /// </summary>
        public bool TwoPlayer
        {
            get => _twoPlayer;
            set => SetProperty(ref _twoPlayer, value);
        }

        /// <summary>
        /// Navigate to the about view
        /// </summary>
        public async void NavigateToAboutView()
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
        public async void NavigateToGamePlayView()
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

        #endregion Properties

    }
}
