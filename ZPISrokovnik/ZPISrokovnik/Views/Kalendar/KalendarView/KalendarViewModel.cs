using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaPlayer;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;
using ZPISrokovnik.Views.Kalendar.KalendarView;

namespace ZPISrokovnik.Views
{
    public class KalendarViewModel : BaseViewModel
    {
        #region Commands
        public ICommand UnesiNapomenuCommand => new Command(UnesiNapomenu);
        public ICommand UrediNapomenuCommand => new Command(UrediNapomenu);
        public ICommand ObrisiNapomenuCommand => new Command(ObrisiNapomenu);
        public ICommand AzurirajCommand => new Command(AzurirajNapomene);
        public ICommand PrikaziNapomenuCommand => new Command<Napomena>(PrikaziNapomenu);
        #endregion

        #region Methods
        private void PrikaziNapomenu(Napomena napomena)
        {
            Application.Current.MainPage.DisplayAlert(napomena.Naziv,
                napomena.Datum.Date.ToString("dd/MM/yyyy") + " - "
                                                           + napomena.DatumDo.Date.ToString("dd/MM/yyyy")
                                                           + '\n' + napomena.Opis, "Uredu");
        }
        private void AzurirajNapomene()
        {
            this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
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
            if (obrisi)
            {
                App.DatabaseController.ObrisiNapomenu(SelectedItem.Id);
                ListaNapomena.Remove(SelectedItem);
                ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
            }
        }
        #endregion

        #region Properties
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
        #endregion

        #region Constructor(s)
        public KalendarViewModel(IPageService page)
        {
            this.ListaNapomena = new ObservableCollection<Napomena>();
            this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
            this.Page = page;
        }

        public KalendarViewModel()
        {
            this.ListaNapomena = null;
            this.ListaNapomena = App.DatabaseController.DohvatiSveNapomene();
        }

        #endregion

        #region PageService

        private readonly IPageService Page;

        #endregion

    }
}
