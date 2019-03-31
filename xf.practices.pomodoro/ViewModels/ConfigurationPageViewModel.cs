using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using xf.practices.pomodoro.Persistence;
namespace xf.practices.pomodoro.ViewModels
{
    public class ConfigurationPageViewModel : NotificationEnabledObject
    {

        public ConfigurationPageViewModel()
        {
            LoadPomodoroDuration();
            LoadBreakDuration();
            LoadConfiguration();
            SaveCommand = new Command(SaveCommandExecute);
        }

        private void LoadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(Literals.PomodoroDuration))
            {
                SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            }
            if (Application.Current.Properties.ContainsKey(Literals.BreakDuration))
            {
                SelectedBreakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
            }
        }

        private void LoadBreakDuration()
        {
            BreakDurations = new ObservableCollection<int>() { 1, 5, 10, 25 };
        }

        private void LoadPomodoroDuration()
        {
            PomodoroDurations = new ObservableCollection<int>()
            { 1, 5, 10, 25 };
        }

        private async void SaveCommandExecute()
        {
            Application.Current.Properties[Literals.PomodoroDuration] = SelectedPomodoroDuration;
            Application.Current.Properties[Literals.BreakDuration] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

        private ObservableCollection<int> _PomodoroDurations;
        public ObservableCollection<int> PomodoroDurations
        {
            get { return _PomodoroDurations; }
            set
            {
                _PomodoroDurations = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> _BreakDurations;
        public ObservableCollection<int> BreakDurations
        {
            get { return _BreakDurations; }
            set
            {
                _BreakDurations = value;
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
