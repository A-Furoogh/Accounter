using Accounter.ViewModels;

namespace Accounter.View;

public partial class Artikel_Seite : ContentPage
{
	public Artikel_Seite(ArtikelVM vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}