using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using xf.practices.pomodoro.Persistence;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace xf.practices.pomodoro.ViewModels
{
    public class HistoryPageViewModel : NotificationEnabledObject
    {

        public HistoryPageViewModel()
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            if (Application.Current.Properties.ContainsKey(Literals.History))
            {
                var json = Application.Current.Properties[Literals.History].ToString();
                var historyList = JsonConvert.DeserializeObject<List<DateTime>>(json);

                PomodoroList = new ObservableCollection<DateTime>(historyList);
            }
        }

        private ObservableCollection<DateTime> _PomodoroList;
        public ObservableCollection<DateTime> PomodoroList
        {
            get { return _PomodoroList; }
            set
            {
                _PomodoroList = value;
                OnPropertyChanged();
            }
        }
    }
}