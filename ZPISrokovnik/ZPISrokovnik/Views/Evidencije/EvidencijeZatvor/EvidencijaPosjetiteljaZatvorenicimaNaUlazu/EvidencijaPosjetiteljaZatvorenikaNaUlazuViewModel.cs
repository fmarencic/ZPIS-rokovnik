using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.JSONModel;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.Evidencije.EvidencijaPosjetiteljaZatvorenicimaNaUlazu
{
    public class EvidencijaPosjetiteljaZatvorenikaNaUlazuViewModel : BaseViewModel
    {
        #region Constructor(s)

        public EvidencijaPosjetiteljaZatvorenikaNaUlazuViewModel(IPageService page)
        {
            pageService = page;
            DohvatiZatvorenike();
        }

        #endregion

        #region Properties

        private string imePrezime;
        public string ImePrezime
        {
            get
            {
                return imePrezime;
            }
            set
            {
                SetValue(ref imePrezime, value);
                OnPropertyChanged(nameof(ImePrezime));
            }
        }

        private string napomena;
        public string Napomena
        {
            get
            {
                return napomena;
            }
            set
            {
                SetValue(ref napomena, value);
                OnPropertyChanged(nameof(Napomena));
            }
        }

        private OsobaDTO zatvorenik;
        public OsobaDTO Zatvorenik
        {
            get
            {
                return zatvorenik;
            }
            set
            {
                SetValue(ref zatvorenik, value);
                OnPropertyChanged(nameof(Zatvorenik));
            }
        }

        private string uloga;
        public string Uloga
        {
            get
            {
                return uloga;
            }
            set
            {
                SetValue(ref uloga, value);
                OnPropertyChanged(nameof(Uloga));
            }
        }

        private DateTime datumDolaska;
        public DateTime DatumDolaska
        {
            get
            {
                return datumDolaska;
            }
            set
            {
                SetValue(ref datumDolaska, value);
                OnPropertyChanged(nameof(DatumDolaska));
            }
        }

        private TimeSpan vrijemeDolaska;
        public TimeSpan VrijemeDolaska
        {
            get
            {
                return vrijemeDolaska;
            }
            set
            {
                SetValue(ref vrijemeDolaska, value);
                OnPropertyChanged(nameof(VrijemeDolaska));
            }
        }

        private DateTime datumOdlaska;
        public DateTime DatumOdlaska
        {
            get
            {
                return datumOdlaska;
            }
            set
            {
                SetValue(ref datumOdlaska, value);
                OnPropertyChanged(nameof(DatumOdlaska));
            }
        }

        private TimeSpan vrijemeOdlaska;
        public TimeSpan VrijemeOdlaska
        {
            get
            {
                return vrijemeOdlaska;
            }
            set
            {
                SetValue(ref vrijemeOdlaska, value);
                OnPropertyChanged(nameof(VrijemeOdlaska));
            }
        }

        private ObservableCollection<OsobaDTO> zatvorenici;
        public ObservableCollection<OsobaDTO> Zatvorenici
        {
            get
            {
                return zatvorenici;
            }
            set
            {
                SetValue(ref zatvorenici, value);
                OnPropertyChanged(nameof(Zatvorenici));
            }
        }

        #endregion

        #region PageService

        private readonly IPageService pageService;

        #endregion

        #region Methods

        private void UnesiEvidenciju()
        {
            EvidencijaPosjetiteljaJSONModel obj = new EvidencijaPosjetiteljaJSONModel();

            try
            {
                obj.ImePrezime = this.ImePrezime;
                obj.Napomena = this.Napomena;
                obj.Uloga = this.Uloga;
                obj.DatumDolaska = this.DatumDolaska.Add(VrijemeDolaska);
                obj.DatumOdlaska = this.DatumOdlaska.Add(VrijemeOdlaska);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            string jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        private void DohvatiZatvorenike()
        {
            var zatvorenici = App.client.DohvatiZatvorenike("", App.TijeloId);

            if (zatvorenici != null)
            {
                foreach (var item in zatvorenici)
                {
                    OsobaDTO o = App.client.DohvatiOsobu("", item.OsobaId);
                    Zatvorenici.Add(o);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand UnesiCommand => new Command(() => UnesiEvidenciju());


        #endregion





    }
}
