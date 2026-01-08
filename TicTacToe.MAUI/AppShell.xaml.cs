using TicTacToe.Views;

namespace TicTacToe;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AboutView), typeof(AboutView));
        Routing.RegisterRoute(nameof(GamePlayView), typeof(GamePlayView));
    }
}
