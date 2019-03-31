using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace xf.practices.pomodoro.ViewModels
{
    public class ConfigurationPageViewModel : NotificationEnabledObject
    {
        public ConfigurationPageViewModel()
        {
            SaveCommand = new Command(SaveCommandExecute);
        }

        private async void SaveCommandExecute()
        {
            App.Current.Properties["PomodoroDuration"] = SelectedPomodoroDuration;
            App.Current.Properties["BreakDuration"] = SelectedBreakDuration;

            await App.Current.SavePropertiesAsync();
        }

        private ObservableCollection<int> _PomodoroDuration;
        public ObservableCollection<int> PomodoroDuration
        {
            get { return _PomodoroDuration; }
            set
            {
                _PomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> _BreakDuration;
        public ObservableCollection<int> BreakDuration
        {
            get { return _BreakDuration; }
            set
            {
                _BreakDuration = value;
                OnPropertyChanged();
            }
        }

        private int _SelectedPomodoroDuration;
        public int SelectedPomodoroDuration
        {
            get { return _SelectedPomodoroDuration; }
            set
            {
                _SelectedPomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private int _SelectedBreakDuration;
        public int SelectedBreakDuration
        {
            get { return _SelectedBreakDuration; }
            set
            {
                _SelectedBreakDuration = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
    }
}
