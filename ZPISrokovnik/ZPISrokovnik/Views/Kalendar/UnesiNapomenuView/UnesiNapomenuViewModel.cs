using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Android.Hardware.Display;
using Android.Views;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Utils.Notifications;
using ZPISrokovnik.Views.Kalendar;
using ZPISrokovnik.Views.Kalendar.KalendarView;

namespace ZPISrokovnik.Views
{
    public class UnesiNapomenuViewModel : BaseViewModel
    {
        #region Commands
        public ICommand UnesiNapomenuCommand => new Command(UnesiNapomenu);
        public ICommand ProvjeriPodatke => new Command(ProvjeraPopunjenosti);
        #endregion

        #region Properties
        private DateTime danas = DateTime.Now;
        public DateTime Danas => danas;

        private bool provjera;
        public bool Provjera
        {
            get { return provjera; }
            set
            {
                SetValue(ref provjera, value);
                OnPropertyChanged(nameof(provjera));
            }
        }

        private Napomena napomena;
        public Napomena Napomena
        {
            get { return napomena; }
            set
            {
                SetValue(ref napomena, value);
                OnPropertyChanged(nameof(Napomena));
            }
        }
        #endregion
        
        #region Constructor(s)
        public UnesiNapomenuViewModel()
        {
            this.Napomena = new Napomena();
        }

        public UnesiNapomenuViewModel(Napomena napomena)
        {
            this.Napomena = napomena;
        }

        #endregion

        #region Methods
        private void ProvjeraPopunjenosti()
        {
            if (!string.IsNullOrEmpty(Napomena.Naziv) &&
                !string.IsNullOrEmpty(Napomena.Opis))
            {
                this.Provjera = true;
                return;
            }
            this.Provjera = false;
        }
        private void UnesiNapomenu()
        {
            if (Provjera)
            {
                this.Napomena.Vidljivo = false;
                App.DatabaseController.SpremiNapomenu(this.Napomena);
                Obavjesti.DodajObavjest();
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }
        #endregion
    }
}
