using Android.App;
using Android.Content.PM;
using Android.OS;

namespace GrocerrrrrryApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            Window.SetStatusBarColor(new Android.Graphics.Color(255, 99, 71));
            Window.SetNavigationBarColor(new Android.Graphics.Color(255, 99, 71));
            base.OnCreate(savedInstanceState);
        }
    }
}
