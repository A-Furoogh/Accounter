using Accounter.ViewModels;


namespace Accounter.View;
public partial class Anmelde_Seite : ContentPage
{
	public Anmelde_Seite()
	{
		InitializeComponent();
        BindingContext = new Anmelde_SeiteViewModel();
	}
}