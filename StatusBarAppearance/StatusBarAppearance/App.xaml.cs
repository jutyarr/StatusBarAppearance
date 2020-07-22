using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StatusBarAppearance.Services;
using StatusBarAppearance.Views;

namespace StatusBarAppearance
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            
            statusBarStyleManager.SetLightTheme();
            //var currentNavPage = (Application.Current.MainPage as NavigationPage);
            //currentNavPage.BarBackgroundColor = Color.Red;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
