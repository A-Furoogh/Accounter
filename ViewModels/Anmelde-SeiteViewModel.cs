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
        

        public BenutzerService _benutzerService;
        public Anmelde_SeiteViewModel(BenutzerService benutzerService)
        {
            _benutzerService = benutzerService;
            
            Title = "Anmelden Seite";
        }
        [ObservableProperty]
        public string benutzername;
        [ObservableProperty]
        public string passwort;

        //[RelayCommand]
        //public async void ShowList()
        //{
        //    var benutzers = await _benutzerService.GetBenutzerList();
        //    if (benutzers?.Count > 0)
        //    {
        //        BenutzerListe.Clear();
        //        foreach (var benutzer in benutzers)
        //        {
        //            BenutzerListe.Add(benutzer);
        //        }
        //    }
        //}
        //[RelayCommand]
        //public async void DeleteBenutzer()
        //{
        //    var benutzer = BenutzerListe.FirstOrDefault();
        //    if (benutzer != null)
        //    {
        //        _benutzerService.DeleteBenutzer(benutzer);
        //        BenutzerListe.Remove(benutzer);
        //        await Application.Current.MainPage.DisplayAlert("Process", "Benutzer gelöscht", "OK");
        //    }
        //}

        [RelayCommand]
        public async void Anmelden()
        {
            IsBusy = true;
            var benutzer = await _benutzerService.GetBenutzerList();
            if (!string.IsNullOrEmpty(benutzer.ToString()))
            {
                //check if user exists in the list with the given password
                if (benutzer.Any(x => x.Benutzername == Benutzername && x.Passwort == Passwort))
                {
                    //navigate to the home page
                    Application.Current.MainPage = new AppShell();
                    IsBusy = false;
                }
                else
                {
                    //Show alert dialog
                    await Application.Current.MainPage.DisplayAlert("Fehler", "Benutzername oder Passwort ist falsch", "OK");
                    IsBusy = false;
                }
            }

        }
    }
}
