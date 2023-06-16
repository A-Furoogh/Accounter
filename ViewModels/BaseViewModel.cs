using CommunityToolkit.Mvvm.ComponentModel;

namespace Accounter.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool _isBusy;
        [ObservableProperty]
        public string _title;
        public bool IsNotBusy => !IsBusy;
    }
}
