using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZPISrokovnik
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; } = false;

        public App()
        {
            InitializeComponent();

            if (!IsUserLoggedIn)
                MainPage = new NavigationPage(new LoginView());
            else
                MainPage = new MainTabbedPage();         
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
