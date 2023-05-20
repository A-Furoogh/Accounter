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
    public partial class ArtikelVM : BaseViewModel
    {
        // Für NeuerArtikel_Seite --------------------------------
        [ObservableProperty]
        public string _artName;
        [ObservableProperty]
        public bool _ausleihbar;
        [ObservableProperty]
        public decimal _preisProTag;
        [ObservableProperty]
        public decimal _preisGesamt;
        [ObservableProperty]
        public int _anzahllager;
        [ObservableProperty]
        public DateTime _ablaufsDatum;
        [ObservableProperty]
        public DateTime _naechstePruefDatum;
        [ObservableProperty]
        public string _lagerPlatz;
        [ObservableProperty]
        public int _bestandLimit;
        [ObservableProperty]
        public int _barcode;
        [ObservableProperty]
        public string _image;
        // -----------------------------------------------
        public ObservableCollection<Artikel> Artikels { get; set; }
        public ObservableCollection<Artikel> SearchedArtikels { get; set; }
        [ObservableProperty]
        public string _searchedWord;

        public IArtikelService _artikelService;
        public ArtikelVM(IArtikelService artikelService) 
        {
            _artikelService = artikelService;
            Title = "Artikel";
            Artikels = new ObservableCollection<Artikel>();
            SearchedArtikels = new ObservableCollection<Artikel>();
            _ = PerformSearch();
        }

        [RelayCommand]
        public async Task GetArtikelList()
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
        // Für NeuerArtikel_Seite---------------------------------------
        public async Task AddArtikel()
        {
            if (IsBusy) { return; }
            try
            {
                IsBusy = true;
                var artikel = new Artikel();
                artikel.ArtName = ArtName;
                artikel.Ausleihbar = Ausleihbar;
                artikel.PreisProTag = PreisProTag;
                artikel.PreisGesamt = PreisGesamt;
                artikel.Anzahllager = Anzahllager;
                artikel.AblaufsDatum = AblaufsDatum;
                artikel.NaechstePruefDatum = NaechstePruefDatum;
                artikel.LagerPlatz = LagerPlatz;
                artikel.BestandLimit = BestandLimit;
                artikel.Barcode = Barcode;
                artikel.Image = Image;
                await _artikelService.AddArtikel(artikel);
                Artikels.Add(artikel);
                SearchedArtikels.Add(artikel);
                await Shell.Current.Navigation.PopAsync();
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
        [RelayCommand]
        public async Task FotoAuswahl() 
        {
            // First ask if the user wants to take a photo or choose from the gallery
            var result = await Shell.Current.DisplayActionSheet("Foto auswählen", "Cancel", null, "Foto aufnehmen", "Aus Galerie auswählen");
            if (result == "Foto aufnehmen")
            {
                await TakePhoto();
            }
            else if (result == "Aus Galerie auswählen")
            {
                await ChoosePhoto();
            }
        }
        // TakePhoto
        async Task TakePhoto()
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                await Shell.Current.DisplayAlert("Error!", "Capture not supported on this device", "OK");
                return;
            }
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                Image = result.FullPath;
            }
        }
        // ChoosePhoto
        async Task ChoosePhoto()
        {
            //if (!MediaPicker.IsPickPhotoSupported)
            //{
            //    await Shell.Current.DisplayAlert("Error!", "Pick photo is not supported on this device", "OK");
            //    return;
            //}
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                Image = result.FullPath;
            }
        }
        // -----------------------------------------------------------

        //DeleteArtikelCommand
        [RelayCommand]
        public async Task DeleteArtikel(Artikel artikel)
        {
            if (IsBusy) { return; }
            try
            {
                IsBusy = true;
                await _artikelService.DeleteArtikel(artikel);
                Artikels.Remove(artikel);
                SearchedArtikels.Remove(artikel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",$"Unable to delete Artikel: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        //UpdateArtikelCommand
        [RelayCommand]
        public async Task UpdateArtikel(Artikel artikel)
        {
            if (IsBusy) { return; }
            try
            {
                IsBusy = true;
                await _artikelService.UpdateArtikel(artikel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to update Artikel: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        public async Task PerformSearch()
        {
            if (IsBusy) { return; }
            else if (string.IsNullOrEmpty(SearchedWord)) 
            { 
                SearchedArtikels.Clear();
                await GetArtikelList();
                for(int i=0; i< Artikels.Count;)
                {
                    SearchedArtikels.Add(Artikels[i]);
                    i++;
                }
                return;
            }
            else
            {
                IsBusy = true;
                SearchedArtikels.Clear();

                foreach (var artikel in Artikels)
                {
                   if (artikel.ArtName.ToLower().Contains(SearchedWord.ToLower()))
                   {
                       SearchedArtikels.Add(artikel);
                   }
                }
                IsBusy = false;
                return;
            }

        }
        [RelayCommand]
        public async Task NeuerArtikelSeite() 
        { 
            await Shell.Current.Navigation.PushModalAsync(new NeuerArtikel_Seite(new ArtikelVM(new ArtikelService())));
        }
        [RelayCommand]
        public async Task Ausleihen(Artikel artikel)
        {
            await Shell.Current.Navigation.PushModalAsync(new NeueAusleihe_Seite(new AusleiheVM(new AusleiheService(),artikel)));
        }
    }
}
