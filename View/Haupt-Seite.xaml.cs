using Accounter.ViewModels;

namespace Accounter.View;

public partial class Haupt_Seite : ContentPage
{
	public Haupt_Seite(Haupt_SeiteVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void BtnArtikelSeite(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Artikel_Seite());
    }
}