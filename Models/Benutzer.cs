using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.ViewModels;

namespace Accounter.Models
{
    public partial class Benutzer : ObservableObject
    {
        //Properties
        [ObservableProperty]
        public string _benutzername;
        [ObservableProperty]
        public string _passwort;
    }
}
