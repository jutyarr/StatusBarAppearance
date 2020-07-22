using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using StatusBarAppearance.Droid.Services;
using StatusBarAppearance.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarStyleManager))]

namespace StatusBarAppearance.Droid.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {
        public void SetDarkTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = 0;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(0, 0, 0));
                });
            }
        }

        public void SetLightTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(253, 253, 253));
                });
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}