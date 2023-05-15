using Accounter.ViewModels;
using Accounter.Services;

namespace Accounter.View;

public partial class Haupt_Seite : ContentPage
{
	public Haupt_Seite(Haupt_SeiteVM vm)
	{
		InitializeComponent();
        this.BindingContext = vm;

    }

    private void BtnArtikelSeite(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Artikel_Seite(new ArtikelVM(new ArtikelService())));
    }
}