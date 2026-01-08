using TicTacToe.ViewModels;

namespace TicTacToe.Views;

public partial class GamePlayView
{
	public GamePlayView(GamePlayViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
		ForceLayout();
    }

    private void ContentPage_SizeChanged(object sender, EventArgs e)
    {
		var viewModel = BindingContext as GamePlayViewModel;
	
		if (viewModel != null)
			viewModel.SizeChanged(Width, Height);
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
		await Task.Delay(500);

		lineLeftVertical.InvalidateMeasure();
		lineBottomHorizontal.InvalidateMeasure();
    }
}