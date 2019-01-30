using System;
using System.Collections.Generic;
using System.Text;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace ZPISrokovnik.Utils.Notifications
{
    public static class Obavjesti
    {
        /// <summary>
        /// Postavlja zadnju obavjest nakon dodavanja nove
        /// </summary>
        public static void DodajObavjest()
        {
            if ((bool)Application.Current.Properties["DodajObavjest"] == false) return;
            var napomena = App.DatabaseController.DohvatiZadnjuNapomenu();
            if (napomena == null) return;
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second+5;
            TimeSpan tS = new TimeSpan(hours, minutes, seconds);
            CrossLocalNotifications.Current.Show(
                napomena.Datum.Date.ToString("dd.MM.yyyy.") + "  " + napomena.Naziv,
                napomena.Opis, napomena.Id,
                napomena.Datum.Date+tS);
        }

        public static void UkljuciObavjesti()
        {
            var napomene = App.DatabaseController.DohvatiSveNapomene();
            if(napomene == null) return;
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second + 5;
            TimeSpan tS = new TimeSpan(hours, minutes, seconds);
            foreach (var napomena in napomene)
            {
                CrossLocalNotifications.Current.Show(
                    napomena.Datum.Date.ToString("dd.MM.yyyy.") + "  " + napomena.Naziv,
                    napomena.Opis, napomena.Id,
                    napomena.Datum.Date + tS);
            }
        }

        public static void IskljuciObavjesti()
        {
            var napomene = App.DatabaseController.DohvatiSveNapomene();
            if(napomene == null) return;
            foreach (var napomena in napomene)
            {
                CrossLocalNotifications.Current.Cancel(napomena.Id);
            }
        }
    }
}
