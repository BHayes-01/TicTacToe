using TicTacToe.ViewModels;

namespace TicTacToe;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}

