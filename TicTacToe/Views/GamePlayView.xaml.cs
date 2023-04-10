using TicTacToe.ViewModels;

namespace TicTacToe.Views;

public partial class GamePlayView
{
	public GamePlayView(GamePlayViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void ContentPage_SizeChanged(object sender, EventArgs e)
    {
		var viewModel = BindingContext as GamePlayViewModel;
	
		if (viewModel != null)
			viewModel.SizeChanged(Width, Height);
    }

}