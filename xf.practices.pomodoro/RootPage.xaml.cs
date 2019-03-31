using System;
using System.Collections.Generic;

using Xamarin.Forms;
using xf.practices.pomodoro.Views;
using xf.practices.pomodoro.ViewModels;

namespace xf.practices.pomodoro
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RootPageViewModel, string>(this, "GoTo", (sender, SelectedMenuItem) =>
             {

                 if (SelectedMenuItem == "Configuracion")
                 {
                     Detail = new NavigationPage(new ConfigurationPage());
                 }
                 else if (SelectedMenuItem == "Pomodoro")
                 {
                     Detail = new NavigationPage(new PomodoroPage());
                 }
                 IsPresented = false;
             });
        }
    }
}
