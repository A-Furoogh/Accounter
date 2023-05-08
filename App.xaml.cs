using Accounter.View;


namespace Accounter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Anmelde_Seite();
	}
}
