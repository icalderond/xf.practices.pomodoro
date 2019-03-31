using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace xf.practices.pomodoro.ViewModels
{
    public abstract class NotificationEnabledObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}