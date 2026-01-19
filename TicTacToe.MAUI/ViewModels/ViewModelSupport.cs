using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TicTacToe.ViewModels;

public partial class ViewModelSupport : ObservableObject
{
    /// <summary>
    /// Exit the program
    /// </summary>
    [RelayCommand]
    public void QuitClick()
    {
        Console.WriteLine("Existing the program...");
        try
        {
            Application.Current?.CloseWindow(Application.Current.MainPage.Window);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during CloseWindow: {ex.Message}");
        }

#if ANDROID
        var activity = Platform.CurrentActivity; // in MAUI, you can get current Android activity this way
        activity.FinishAffinity();
        Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#else
            Environment.Exit(0);
#endif
    }
}
