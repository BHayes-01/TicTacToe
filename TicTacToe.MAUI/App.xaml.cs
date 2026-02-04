using System.Diagnostics;
using TicTacToe.ViewModels;

namespace TicTacToe;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // 1. Catches exceptions on the main thread (Synchronous)
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            LogException(e.ExceptionObject as Exception, "AppDomain");
        };

        // 2. Catches exceptions in background tasks (Asynchronous)
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            LogException(e.Exception, "TaskScheduler");
            // e.SetObserved(); // Optional: prevents the app from crashing in some scenarios
        };

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

    private void LogException(Exception ex, string source)
    {
        // Use your logger of choice (e.g., Serilog, AppCenter, or Sentry)
        Console.WriteLine($"Critical Error from {source}: {ex?.Message}");
    }

}
