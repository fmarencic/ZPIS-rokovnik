using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;
using ZPISrokovnik.Views.Kalendar.KalendarView;

namespace ZPISrokovnik.Views
{
    public class KalendarViewModel : BaseViewModel
    {
        public ICommand UnesiNapomenuCommand => new Command(UnesiNapomenu);
        public ICommand UrediNapomenuCommand => new Command(UrediNapomenu);
        public ICommand ObrisiNapomenuCommand => new Command(ObrisiNapomenu);

        private ObservableCollection<Napomena> listaNapomena;
        public ObservableCollection<Napomena> ListaNapomena
        {
            get { return listaNapomena; }
            set
            {
                SetValue(ref listaNapomena, value);
                OnPropertyChanged(nameof(ListaNapomena));
            }
        }

        private Napomena selectedItem;
        public Napomena SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    if (selectedItem != null)
                    {
                        selectedItem.Vidljivo = false;
                    }
                    selectedItem = value;
                    selectedItem.Vidljivo = true;
                }
            }
        }

        private readonly IPageService Page;

        public KalendarViewModel(IPageService page)
        {
            this.ListaNapomena = null;
            this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
            this.Page = page;
        }

        private void UnesiNapomenu()
        {
            Page.PushAsync(new UnesiNapomenuView());
        }

        private void UrediNapomenu()
        {
            Page.PushAsync(new UnesiNapomenuView(SelectedItem));
        }

        private async void ObrisiNapomenu()
        {
            var obrisi = await Application.Current.MainPage.DisplayAlert("Obriši?",
                "Želite li obrisati napomenu " + SelectedItem.Naziv + "?", "Uredu",
                "Odustani");
            //bool obrisi = await Page.DisplayAlert("Obriši?",
            //    "Želite li obrisati napomenu " + SelectedItem.Naziv + "?", "Uredu",
            //    "Odustani");
            if (obrisi) //obrisi
            {
                App.DatabaseController.ObrisiNapomenu(SelectedItem.Id);
                ListaNapomena.Remove(SelectedItem);
                ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
                //this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
                //mislim da ni ova zadnja nije potrebna linija jer je observablecollection vidi
                //Page.PushAsync(new KalendarView());

            }
        }
        
    }
}
