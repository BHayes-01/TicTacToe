using System.Diagnostics;
using TicTacToe.ViewModels;

namespace TicTacToe;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = base.CreateWindow(activationState);

        // This is the cross-platform hook for "The app is closing/destroying"
        window.Destroying += (s, e) =>
        {
            CleanUpResources();
        };

        return window;
    }

    private void CleanUpResources()
    {
        // dispose of the game play View model when the page is unloaded
        var vm = Handler.MauiContext.Services.GetService<GamePlayViewModel>();
        vm?.Dispose();

        // 2. Perform other cleanup (close DB connections, stop timers, etc.)
        //Debug.WriteLine("App is disposing resources...");
    }

}
