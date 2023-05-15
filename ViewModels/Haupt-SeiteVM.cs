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
            Title = "Haupt Seite";
        }
    }
}
