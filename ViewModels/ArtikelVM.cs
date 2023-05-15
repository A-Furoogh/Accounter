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
    public partial class ArtikelVM : BaseViewModel
    {
        public ObservableCollection<Artikel> Artikels { get; set; } = new();
        public IArtikelService _artikelService;
        public ArtikelVM(IArtikelService artikelService) 
        {
            _artikelService = artikelService;
            Title = "Artikel";
        }

        [RelayCommand]
        async Task GetArtikelList()
        {
            if (IsBusy) { return; }
            try
            {
                IsBusy = true;
                var artikels = await _artikelService.GetArtikelList();
                if (artikels?.Count > 0)
                {
                    Artikels.Clear();
                    foreach (var artikel in artikels)
                    {
                        Artikels.Add(artikel);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",$"Unable to get Artikels: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        public async Task AddArtikel()
        {
            if (IsBusy) { return; }
            try
            {
                IsBusy = true;
                var artikel = new Artikel();
                await _artikelService.AddArtikel(artikel);
                Artikels.Add(artikel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",$"Unable to add Artikel: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
