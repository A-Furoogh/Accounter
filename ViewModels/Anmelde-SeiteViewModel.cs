using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Accounter.Services;

namespace Accounter.ViewModels
{
    public partial class Anmelde_SeiteViewModel : BaseViewModel
    {
        // _benutzerService ist die Instanz von IBenutzerService interface
        public IBenutzerService _benutzerService;
        public Anmelde_SeiteViewModel(IBenutzerService benutzerService)
        {
            _benutzerService = benutzerService;
            
            Title = "Anmelden Seite";
        }
        // Eigenschaften für die Benutzername und Passwort
        [ObservableProperty]
        public string _benutzername;
        [ObservableProperty]
        public string _passwort;

        [RelayCommand]
        public async void Anmelden()
        {
            IsBusy = true;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Keine Internetverbindung", "Bitte stellen Sie eine Internetverbindung her", "OK");
                IsBusy = false;
                return;
            }
            var benutzer = await _benutzerService.GetBenutzerList();
            if (!string.IsNullOrEmpty(benutzer.ToString()))
            {
                //prüfen ob der Benutzername und das Passwort in der Datenbank vorhanden sind
                if (benutzer.Any(x => x.Benutzername == Benutzername && x.Passwort == Passwort))
                {
                    //Navigiere zu der Hauptseite
                    Application.Current.MainPage = new AppShell();
                    IsBusy = false;
                }
                else
                {
                    //Zeige eine Fehlermeldung
                    await Application.Current.MainPage.DisplayAlert("Fehler", "Benutzername oder Passwort ist falsch", "OK");
                    IsBusy = false;
                }
            }

        }
    }
}
