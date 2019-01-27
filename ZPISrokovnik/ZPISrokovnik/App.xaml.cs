<<<<<<< HEAD
﻿using Xamarin.Forms;
=======
﻿using Android.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
>>>>>>> 480b348bd8af586489df992ba9cbb5bd21792def
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Utils.Data;
using ZPISrokovnik.Views;
using ZPISrokovnik.Views.Kalendar;

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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjI0OThAMzEzNjJlMzQyZTMwbUR2VHdMRmdjZ0NtSkxNbUhDalp6cXpmL0VMMlNtczR1Z0hmNngzZFUvcz0=");
            InitializeComponent();
            client = new Service1Client(ServiceConnection.CreateBasicHttpBinding(), ServiceConnection.Endpoint);
            NapomenaBaza();
            Obavjesti();
            MainPage = new NavigationPage(new LoginView());
        }

        /// <summary>
        /// Postavljanje obavjesti napomena
        /// </summary>
        public static void Obavjesti()
        {
            ObservableCollection<Napomena> napomene = App.DatabaseController.DohvatiSveNapomene();
            for (int i = 0; i < napomene.Count; i++)
            {
                CrossLocalNotifications.Current.Show(
                    napomene[i].Datum.Date.ToString("dd.MM.yyyy.") + "  " + napomene[i].Naziv,
                    napomene[i].Opis, napomene[i].Id,
                    napomene[i].Datum.Date);
            }
        }

        /// <summary>
        /// Inicijalizacija kontrolera lokalne baze
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
