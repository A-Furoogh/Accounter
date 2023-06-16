﻿using Accounter.View;
using CommunityToolkit.Mvvm.Input;

namespace Accounter.ViewModels
{
    public partial class Haupt_SeiteVM : BaseViewModel
    {
        public Haupt_SeiteVM()
        {
            Title = "Home";
        }
        //Hier werden die Commands für die Buttons erstellt
        [RelayCommand]
        public async Task GotoArtikelPage()
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(Artikel_Seite));
            IsBusy = false;
        }
        [RelayCommand]
        public async Task GotoKundenPage()
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(Kunden_Seite));
            IsBusy = false;
        }
        [RelayCommand]
        public async Task GotoAusleihePage()
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(Ausleihe_Seite));
            IsBusy = false;
        }
        [RelayCommand]
        public async Task GotoEinkaufPage()
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(Einkauf_Seite));
            IsBusy = false;
        }
    }
}
