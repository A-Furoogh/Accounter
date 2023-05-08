using Accounter.ViewModels;

namespace Accounter.View;

public partial class Haupt_Seite : ContentPage
{
	public Haupt_Seite()
	{
		InitializeComponent();
        var an = new Anmelde_Seite();
        
    }

    private void BtnArtikelSeite(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Artikel_Seite());
    }
}