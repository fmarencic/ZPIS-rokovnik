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
            CrossLocalNotifications.Current.Show(
                napomena.Datum.Date.ToString("dd.MM.yyyy.") + "  " + napomena.Naziv,
                napomena.Opis, napomena.Id,
                napomena.Datum.Date);
        }
    }
}
