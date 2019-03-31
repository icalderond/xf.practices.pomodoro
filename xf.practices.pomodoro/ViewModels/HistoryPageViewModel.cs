using System;
using System.Collections.ObjectModel;
namespace xf.practices.pomodoro.ViewModels
{
    public class HistoryPageViewModel : NotificationEnabledObject
    {
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