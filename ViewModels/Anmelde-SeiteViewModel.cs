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

namespace Accounter.ViewModels
{
    public partial class Anmelde_SeiteViewModel : BaseViewModel
    {
        

        [ObservableProperty]
        ObservableCollection<Benutzer> _benutzerListe;    
        public Anmelde_SeiteViewModel()
        {
            _benutzerListe = new();
            _benutzerListe.Add(new Benutzer() { Benutzername="Admin", Passwort="12345"});
        }

        [RelayCommand]
        public void Anmelden()
        {
            if (!string.IsNullOrEmpty(Benutzername) && !string.IsNullOrEmpty(Passwort))
            {
                //check if user exists in the list with the given password
                if (BenutzerListe.Any(x => x.Benutzername == Benutzername && x.Passwort == Passwort))
                {
                    //navigate to the home page
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    //show error message
                    Application.Current.MainPage.DisplayAlert("Error", "Benutzername oder Passwort ist falsch", "OK");
                }
            }
            
        }
    }
}
