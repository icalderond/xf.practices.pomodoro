using System;
using Xamarin.Forms;
using System.Timers;
namespace xf.practices.pomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationEnabledObject
    {
        Timer timer;

        public PomodoroPageViewModel()
        {
            InitializeTimer();
            StartOrPauseCommand = new Command(StartOrPauseExecute);
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));
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

        private string _AvancePomodoro;
        public string AvancePomodoro
        {
            get { return _AvancePomodoro; }
            set
            {
                _AvancePomodoro = value;
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
