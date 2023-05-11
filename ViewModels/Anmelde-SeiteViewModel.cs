using Accounter.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.Models;
using Accounter.Services;
using System.Diagnostics.Contracts;

namespace Accounter.ViewModels
{
    public partial class Anmelde_SeiteViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Benutzer> benutzerListe = new()
        {
            new Benutzer { Benutzername = "Admin", Passwort = "12345"},
            new Benutzer { Benutzername = "User", Passwort = "12345"}
        };
        public readonly IBenutzerService _benutzerService;
        public Anmelde_SeiteViewModel(IBenutzerService benutzerService)
        {
            
            _benutzerService = benutzerService;
        }
        [ObservableProperty]
        public string benutzername;
        [ObservableProperty]
        public string passwort;

        [RelayCommand]
        public async void ShowList()
        {
            var benutzers = await _benutzerService.GetBenutzerList();
            if (benutzers?.Count > 0)
            {
                BenutzerListe.Clear();
                foreach (var benutzer in benutzers)
                {
                    BenutzerListe.Add(benutzer);
                }
            }
        }

        [RelayCommand]
        public async void Anmelden()
        {
            if (!string.IsNullOrEmpty(BenutzerListe.ToString()))
            {
                //check if user exists in the list with the given password
                if (BenutzerListe.Any(x => x.Benutzername == Benutzername && x.Passwort == Passwort))
                {
                    //navigate to the home page
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    //Show alert dialog
                    await Application.Current.MainPage.DisplayAlert("Fehler", "Benutzername oder Passwort ist falsch", "OK");
                }
            }
            
        }
    }
}
