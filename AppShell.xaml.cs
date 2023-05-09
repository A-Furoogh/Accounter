

using Accounter.View;

namespace Accounter;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Haupt_Seite), typeof(Haupt_Seite));
	}

    private void ShellContent_ChildAdded(object sender, ElementEventArgs e)
    {

    }
}
