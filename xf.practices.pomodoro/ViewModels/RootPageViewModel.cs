using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace xf.practices.pomodoro.ViewModels
{
    public class RootPageViewModel : NotificationEnabledObject
    {
        public RootPageViewModel()
        {
            MenuItems = new ObservableCollection<string>()
            {
                "Pomodoro","Historico", "Configuracion"
            };

            PropertyChanged += RootPageViewModel_PropertyChanged;
        }

        void RootPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedMenuItem))
            {
                MessagingCenter.Send(this, "GoTo", SelectedMenuItem);
            }
        }


        private ObservableCollection<string> _MenuItems;
        public ObservableCollection<string> MenuItems
        {
            get { return _MenuItems; }
            set
            {
                _MenuItems = value;
                OnPropertyChanged();
            }
        }

        private string _SelectedMenuItem;
        public string SelectedMenuItem
        {
            get { return _SelectedMenuItem; }
            set
            {
                _SelectedMenuItem = value;
                OnPropertyChanged();
            }
        }
    }
}