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
        public ICommand UnesiNapomenuCommand => new Command(() => UnesiNapomenu());
        public ICommand UrediNapomenuCommand => new Command(() => UrediNapomenu());
        public ICommand ObrisiNapomenuCommand => new Command(() => ObrisiNapomenu());

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
        public List<string> TipKalendara =
            new List<string>()
            {
                "Napomena tjeralica",
                "Napomena preprata",
                "Napomena najava"
            };

        private Napomena selectedItem;
        public Napomena SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetValue(ref selectedItem, value);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private readonly IPageService Page;

        public KalendarViewModel(IPageService page)
        {
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
            Page.PushAsync(new UnesiNapomenuView(SelectedItem));
        }

        private async void ObrisiNapomenu()
        {
            bool obrisi = await Page.DisplayAlert("Obriši?",
                "Želite li obrisati napomenu " + SelectedItem.Naziv + "?", "Uredu",
                "Odustani");
            if (obrisi)
            {
                App.DatabaseController.ObrisiNapomenu(SelectedItem.Id);
                this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
                //mislim da ni ova zadnja nije potrebna linija jer je observablecollection vidi
            }
        }
        
    }
}
