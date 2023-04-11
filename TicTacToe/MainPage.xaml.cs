using TicTacToe.ViewModels;

namespace TicTacToe;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}

}

