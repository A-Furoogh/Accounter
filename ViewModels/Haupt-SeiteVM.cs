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
            await Shell.Current.GoToAsync(nameof(Artikel_Seite));
        }
        [RelayCommand]
        public async Task GotoKundenPage()
        {
            await Shell.Current.GoToAsync(nameof(Kunden_Seite));
        }
        [RelayCommand]
        public async Task GotoAusleihePage()
        {
            await Shell.Current.GoToAsync(nameof(Ausleihe_Seite));
        }
        [RelayCommand]
        public async Task GotoEinkaufPage()
        {
            await Shell.Current.GoToAsync(nameof(Einkauf_Seite));
        }
    }
}
