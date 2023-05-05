namespace Buchhalter_ME.View;

public partial class Haupt_Seite : ContentPage
{
	public Haupt_Seite()
	{
		InitializeComponent();
        
    }

    private void BtnArtikelSeite(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Artikel_Seite());
    }
}