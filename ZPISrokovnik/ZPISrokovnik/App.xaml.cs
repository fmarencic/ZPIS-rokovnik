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
        public static string KorisnickoIme { get; internal set; }
        public static string KorisnickaOznaka { get; internal set; }

        public static Service1Client client;

        public static StorageDatabaseController DatabaseController = new StorageDatabaseController();
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjI0OThAMzEzNjJlMzQyZTMwbUR2VHdMRmdjZ0NtSkxNbUhDalp6cXpmL0VMMlNtczR1Z0hmNngzZFUvcz0=");
            InitializeComponent();
            client = new Service1Client(ServiceConnection.CreateBasicHttpBinding(), ServiceConnection.Endpoint);
            MainPage = new NavigationPage(new LoginView());
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
