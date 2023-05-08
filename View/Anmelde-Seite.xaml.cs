namespace Accounter.View;

public partial class Anmelde_Seite : ContentPage
{
	public Anmelde_Seite()
	{
		InitializeComponent();
	}

    private void Btn_Anmelden(object sender, EventArgs e)
    {
        this.Navigation.PopModalAsync();
        Application.Current.MainPage = new AppShell();
    }
}