using Accounter.ViewModels;
using Accounter.View;
using Microsoft.Extensions.Logging;

namespace Accounter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<Haupt_Seite>();
		builder.Services.AddSingleton<Haupt_SeiteVM>();

        builder.Services.AddSingleton<Anmelde_Seite>();
        builder.Services.AddSingleton<Anmelde_SeiteViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
