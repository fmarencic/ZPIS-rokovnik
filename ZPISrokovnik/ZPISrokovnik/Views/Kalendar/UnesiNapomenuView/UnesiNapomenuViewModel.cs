using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Android.Views;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;

namespace ZPISrokovnik.Views
{
    public class UnesiNapomenuViewModel : BaseViewModel
    {
        public ICommand UnesiNapomenuCommand => new Command(() => UnesiNapomenu()));
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

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                SetValue(ref datum, value);
                OnPropertyChanged(nameof(datum));
            }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                SetValue(ref naziv, value);
                OnPropertyChanged(nameof(naziv));
            }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set
            {
                SetValue(ref opis, value);
                OnPropertyChanged(nameof(opis));
            }
        }

        public UnesiNapomenuViewModel()
        {
            this.Napomena = new Napomena();
        }

        public UnesiNapomenuViewModel(Napomena napomena)
        {
            this.Napomena = napomena;
        }

        private void UnesiNapomenu()
        {
            App.DatabaseController.SpremiNapomenu(this.Napomena);
            Console.WriteLine("Unio" + Napomena.Naziv);

        }

    }
}
