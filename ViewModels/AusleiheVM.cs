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
using System.Diagnostics;
using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Maui.Controls.PlatformConfiguration;


namespace Accounter.ViewModels
{
    public partial class AusleiheVM :BaseViewModel
    {
        public IAusleiheService _ausleiheService;
        [ObservableProperty]
        public string _artName;
        [ObservableProperty]
        public string _image;
        [ObservableProperty]
        public int _ArtID;
        [ObservableProperty]
        public DateTime _ausleiheDatum;
        [ObservableProperty]
        public DateTime _AbgabeFrist;
        [ObservableProperty]
        public int _kundID;
        [ObservableProperty]
        public int _artAnzahl;
        public AusleiheVM(IAusleiheService ausleiheService,Artikel artikel)
        {
            _ausleiheService = ausleiheService;
            ArtName = artikel.ArtName.ToString();
            Image = artikel.Image;
            ArtID = artikel.ArtID;
            AusleiheDatum = DateTime.Now;
            AbgabeFrist = DateTime.Now.AddDays(7);
        }
        [RelayCommand]
        public async Task ArtikelAusleihen()
        {
            if(AusleiheDatum > AbgabeFrist)
            {
                await Shell.Current.DisplayAlert("Fehler", "Das Ausleihedatum darf nicht größer als die Abgabefrist sein", "OK");
                return;
            }
            if(ArtAnzahl <= 0)
            {
                await Shell.Current.DisplayAlert("Fehler", "Die Anzahl darf nicht kleiner als 1 sein", "OK");
                return;
            }
            if (KundID <= 0) 
            {
                await Shell.Current.DisplayAlert("Fehler", "Die Kunden-ID darf nicht leer sein", "OK");
                return;
            }
            var ausleihe = new Ausleihe()
            {
                ArtID = ArtID,
                AusleiheDatum = AusleiheDatum,
                AbgabeFrist = AbgabeFrist,
                KundID = KundID,
                ArtAnzahl = ArtAnzahl
            };
            await _ausleiheService.AddAusleihe(ausleihe);
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        public async Task Abbrechen()
        {
            await Shell.Current.GoToAsync("..");
        }
        
    }
}
