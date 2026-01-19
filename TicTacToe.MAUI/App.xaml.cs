using System.Diagnostics;

namespace TicTacToe;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public void Dispose()
    {
        // This will now be called more reliably when the Page is popped
        // because the VM is Transient, not Singleton.
        Debug.WriteLine("ViewModel Disposed");
    }

}
