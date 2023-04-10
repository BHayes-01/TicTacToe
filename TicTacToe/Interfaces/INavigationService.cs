using TicTacToe.Enums;

namespace TicTacToe.Interfaces
{
    public interface INavigationService
    {

        Task NavigateAbout();

        Task NavigateGamePlay();

        Task NavigateMain();

    }
}
