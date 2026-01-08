using TicTacToe.ViewModels;

namespace TicTacToe.Views;

public partial class AboutView 
{
	public AboutView(AboutViewModel viewModel) 
	{
		InitializeComponent();
        BindingContext = viewModel;	
    }

	
}