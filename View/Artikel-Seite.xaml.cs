namespace Accounter.View;

public partial class Artikel_Seite : ContentPage
{
	public Artikel_Seite(Artikel_Seite vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}