using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils.Data;
using ZPISrokovnik.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZPISrokovnik
{
    public partial class App : Application
    {
<<<<<<< HEAD
=======
        public static bool IsUserLoggedIn { get; set; } = false;

        public static StorageDatabaseController DatabaseController;
>>>>>>> 9cc9c8339029fa7ec0bdb5e4a4abe3582d979da0
        public App()
        {
            InitializeComponent();       
        }

        /// <summary>
        /// App.NapomenaBaza.Metoda
        /// </summary>
        /// <returns></returns>
        public static StorageDatabaseController NapomenaBaza()
        {
            if (DatabaseController == null)
            {
                DatabaseController = new StorageDatabaseController();
            }
            return DatabaseController;
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
