using Xamarin.Forms;
using xf.practices.pomodoro.ViewModels;
using xf.practices.pomodoro.Views;

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

                if (SelectedMenuItem == "Historico")
                {
                    Detail = new NavigationPage(new HistoryPage());
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