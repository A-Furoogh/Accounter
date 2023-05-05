namespace Buchhalter_ME.View;

public partial class AnmeldeSeite : ContentPage
{
	public AnmeldeSeite()
	{
		InitializeComponent();
	}

    private void Btn_Anmelden(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new Haupt_Seite());
    }
}