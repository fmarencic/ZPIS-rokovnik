using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;

namespace ZPISrokovnik.Views
{
    public class KalendarViewModel : BaseViewModel
    {
        public ObservableCollection<Napomena> ListaNapomena { get; set; }
        public ICommand UnesiNapomenuCommand { get; private set; }
        public ICommand UrediNapomenuCommand { get; private set; }
        public ICommand ObrisiNapomenuCommand { get; private set; }

        public List<string> TipKalendara =
            new List<string>()
            {
                "Napomena tjeralica",
                "Napomena preprata",
                "Napomena najava"
            };

        public Napomena ElementListeNapomena
        {
            get { return ElementListeNapomena; }
            set
            {
                if (ElementListeNapomena != value)
                {
                    ElementListeNapomena.Vidljivo = true;
                }
            }
        }

        private readonly IPageService Page;

        //private Napomena SelektiranaNapomena;

        //public Napomena ElementListeNapomena
        //{
        //    get { return SelektiranaNapomena; }
        //    set
        //    {
        //        if (SelektiranaNapomena != value)
        //        {
        //            SelektiranaNapomena = value;
        //            OnPropertyChanged("ItemSelected");
        //            /*
        //             * And if you want to perform any additional
        //             * functionality like navigating to detail page,
        //             * you can do it from the set property after
        //             * OnPropertyChanged statement is executed.
        //             */
        //            SelektiranaNapomena.Vidljivo = true;
        //            //ovo ce trebat fixat jer ce vidljivo ostat njima true i nakon..
        //        }
        //    }
        //}

        //mislim da je binding dobar tako za viewcell

        public KalendarViewModel(IPageService page)
        {
            UnesiNapomenuCommand = new Command(UnesiNapomenu);
            UrediNapomenuCommand = new Command(UrediNapomenu);
            ObrisiNapomenuCommand = new Command(ObrisiNapomenu);
            this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
            this.Page = page;
        }

        //CommandParameter="{Binding Source={x:Reference entry}, Path=Text}"
        private void UnesiNapomenu()
        {
            Page.PushAsync(new UnesiNapomenuView());
        }

        private void UrediNapomenu()
        {
            //selektiranaNapomena i dole 2 x
            Page.PushAsync(new UnesiNapomenuView(ElementListeNapomena));
        }

        private async void ObrisiNapomenu()
        {
            bool obrisi = await Page.DisplayAlert("Obriši?",
                "Želite li obrisati napomenu " + ElementListeNapomena.Naziv + "?", "Uredu",
                "Odustani");
            if (obrisi)
            {
                App.DatabaseController.ObrisiNapomenu(ElementListeNapomena.Id);
                this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
                //mislim da ni ova zadnja nije potrebna linija jer je observablecollection vidi
            }
        }
        
    }
}
