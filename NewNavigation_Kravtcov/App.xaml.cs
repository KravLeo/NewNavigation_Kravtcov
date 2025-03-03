using NewNavigation_Kravtcov.mvvm.View;

namespace NewNavigation_Kravtcov
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
