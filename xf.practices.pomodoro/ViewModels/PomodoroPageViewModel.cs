using System;
using Xamarin.Forms;
using System.Timers;
using xf.practices.pomodoro.Persistence;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace xf.practices.pomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationEnabledObject
    {
        Timer timer;
        private int pomodoroDuration;
        private int breakDuration;

        public PomodoroPageViewModel()
        {
            InitializeTimer();
            LoadConfigureValues();
            StartOrPauseCommand = new Command(StartOrPauseExecute);
        }

        private void LoadConfigureValues()
        {
            pomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            breakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));

            if (IsRunning && Ellapsed.TotalSeconds == pomodoroDuration * 60)
            {
                IsRunning = false;
                IsInBreak = true;
                Ellapsed = TimeSpan.Zero;

                await SavePomodoroAsync();
            }

            if (IsInBreak && Ellapsed.TotalSeconds == pomodoroDuration * 60)
            {
                IsRunning = true;
                IsInBreak = false;
                Ellapsed = TimeSpan.Zero;
            }
        }

        private async Task SavePomodoroAsync()
        {
            var historyList = new List<DateTime>();
            if (Application.Current.Properties.ContainsKey(Literals.History))
            {
                var jsonList = Application.Current.Properties[Literals.History].ToString();
                historyList = JsonConvert.DeserializeObject<List<DateTime>>(jsonList);
            }

            historyList.Add(DateTime.Now);

            var historyListSerialized = JsonConvert.SerializeObject(historyList);

            Application.Current.Properties[Literals.History] = historyListSerialized;
            await Application.Current.SavePropertiesAsync();
        }

        void StartTimer()
        {
            timer.Start();
            IsRunning = true;
        }

        void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }

        private void StartOrPauseExecute()
        {
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        private TimeSpan _Ellapsed;
        public TimeSpan Ellapsed
        {
            get { return _Ellapsed; }
            set
            {
                _Ellapsed = value;
                OnPropertyChanged();
            }
        }

        private bool _IsInBreak;
        public bool IsInBreak
        {
            get { return _IsInBreak; }
            set
            {
                _IsInBreak = value;
                OnPropertyChanged();
            }
        }

        private bool _IsRunning;

        public bool IsRunning
        {
            get { return _IsRunning; }
            set
            {
                _IsRunning = value;
                OnPropertyChanged();
            }
        }

        public Command StartOrPauseCommand { get; set; }
    }
}
