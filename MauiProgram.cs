using Accounter.ViewModels;
using Accounter.View;
using Microsoft.Extensions.Logging;
using Accounter.Services;

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
		string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Accounter.db");
		

#if DEBUG
        builder.Logging.AddDebug();
#endif
		//Services
		builder.Services.AddSingleton<IBenutzerService, BenutzerService>(s => ActivatorUtilities.CreateInstance<BenutzerService>(s, dbPath));
		builder.Services.AddSingleton<IArtikelService, ArtikelService>();

        //Views
        builder.Services.AddSingleton<Haupt_Seite>();
        builder.Services.AddSingleton<Anmelde_Seite>();
		builder.Services.AddSingleton<Artikel_Seite>();

		//ViewModels
		builder.Services.AddSingleton<Anmelde_SeiteViewModel>();
		builder.Services.AddSingleton<Haupt_SeiteVM>();
		builder.Services.AddSingleton<ArtikelVM>();





        return builder.Build();
	}
}
