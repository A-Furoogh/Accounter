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
		

#if DEBUG
        builder.Logging.AddDebug();
#endif
		//Services
		builder.Services.AddSingleton<IBenutzerService, BenutzerService>();
		builder.Services.AddSingleton<IArtikelService, ArtikelService>();
		builder.Services.AddSingleton<IAusleiheService, AusleiheService>();

        //Views
        builder.Services.AddSingleton<Haupt_Seite>();
        builder.Services.AddSingleton<Anmelde_Seite>();
		builder.Services.AddSingleton<Artikel_Seite>();
        builder.Services.AddSingleton<NeuerArtikel_Seite>();
		builder.Services.AddSingleton<NeueAusleihe_Seite>();

        //ViewModels
        builder.Services.AddSingleton<Anmelde_SeiteViewModel>();
		builder.Services.AddSingleton<Haupt_SeiteVM>();
		builder.Services.AddSingleton<ArtikelVM>();
		builder.Services.AddSingleton<AusleiheVM>();


        return builder.Build();
	}
}
