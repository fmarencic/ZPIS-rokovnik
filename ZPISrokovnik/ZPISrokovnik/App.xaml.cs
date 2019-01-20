using Android.Net;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Utils.Data;
using ZPISrokovnik.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZPISrokovnik
{
    public partial class App : Application
    {
        public static string Token { get; set; }
        public static long TijeloId { get; set; }

        public static Service1Client client;

        public static StorageDatabaseController DatabaseController;
        public App()
        {
            InitializeComponent();
            client = new Service1Client(ServiceConnection.CreateBasicHttpBinding(), ServiceConnection.Endpoint);
<<<<<<< HEAD

            NapomenaBaza();
=======
            MainPage = new NavigationPage(new LoginView());
>>>>>>> 06c8959b9db1df06032a19062da47ab06d7ea0ef
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
