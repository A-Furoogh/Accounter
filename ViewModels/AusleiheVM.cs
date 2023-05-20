﻿using Accounter.View;
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
        public AusleiheVM(IAusleiheService ausleiheService,Artikel artikel)
        {
            _ausleiheService = ausleiheService;
            ArtName = artikel.ArtName.ToString();
        }
        

        
    }
}
