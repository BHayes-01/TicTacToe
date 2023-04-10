using TicTacToe.Interfaces;
using TicTacToe.Views;

namespace TicTacToe.Services
{
    public class NavigationService : INavigationService
    {

        /// <summary>
        /// Navigate to the about page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task NavigateAbout()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AboutView));
            }
            catch
            {
                throw new InvalidOperationException($"Unable to resolve type {nameof(AboutView)}");
            }
        }

        /// <summary>
        /// Navigate to the game (tic-tac-toe)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task NavigateGamePlay()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(GamePlayView));
            }
            catch
            {
                throw new InvalidOperationException($"Unable to resolve type {nameof(GamePlayView)}");
            }
        }

        /// <summary>
        /// Navigate to the main start form
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task NavigateMain()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            catch
            {
                throw new InvalidOperationException($"Unable to resolve type {nameof(MainPage)}");
            }
        }

    }
}
