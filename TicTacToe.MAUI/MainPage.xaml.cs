using TicTacToe.ViewModels;

namespace TicTacToe;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Subscribe to the Unloaded event directly
        this.Unloaded += (s, e) =>
        {
            // dispose of the ViewModel when the page is unloaded
            var vm = Handler.MauiContext.Services.GetService<GamePlayViewModel>();
            vm?.Dispose();
        };

    }

}

