using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TicTacToe.Views;
using TicTacToe.ViewModels;

namespace TicTacToe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
        builder.Services.AddSingleton<GamePlayView>();
        builder.Services.AddSingleton<GamePlayViewModel>();

        builder.Services.AddSingleton<AboutView>();
        builder.Services.AddSingleton<AboutViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        return builder;
	}

}
