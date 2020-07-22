using StatusBarAppearance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatusBarAppearance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeThemePage : ContentPage
    {
        public ChangeThemePage()
        {
            InitializeComponent();
        }

        private void btnLight_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
                //  currentNavPage.BarBackgroundColor = Color.DarkCyan;
                statusBarStyleManager.SetLightTheme();
            });
        }
        private void btnDark_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
                //  currentNavPage.BarBackgroundColor = Color.DarkCyan;
                statusBarStyleManager.SetDarkTheme();
            });
        }
    }
}