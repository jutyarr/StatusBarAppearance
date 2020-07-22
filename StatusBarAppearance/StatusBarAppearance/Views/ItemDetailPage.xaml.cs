using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StatusBarAppearance.Models;
using StatusBarAppearance.ViewModels;
using StatusBarAppearance.Services;

namespace StatusBarAppearance.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            ChangeColorOfStatus();
        }
        void ChangeColorOfStatus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currentNavPage = (Application.Current.MainPage as NavigationPage);
                var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
              //  currentNavPage.BarBackgroundColor = Color.DarkCyan;
                statusBarStyleManager.SetDarkTheme();
                /*
                if (++tickNum % 2 == 0)
                {
                    currentNavPage.BarBackgroundColor = Color.DarkCyan;
                    statusBarStyleManager.SetDarkTheme();
                }
                else
                {
                    currentNavPage.BarBackgroundColor = Color.LightGreen;
                    statusBarStyleManager.SetLightTheme();
                }
                */
            });
        }
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}