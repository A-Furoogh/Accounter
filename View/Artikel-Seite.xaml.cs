using Accounter.Services;
using Accounter.ViewModels;

namespace Accounter.View;

public partial class Artikel_Seite : ContentPage
{ArtikelVM vm = new(new ArtikelService());
	public Artikel_Seite(ArtikelVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    //protected override void OnAppearing()
    //{
    //   _ = vm.GetArtikelList();
    //}
}