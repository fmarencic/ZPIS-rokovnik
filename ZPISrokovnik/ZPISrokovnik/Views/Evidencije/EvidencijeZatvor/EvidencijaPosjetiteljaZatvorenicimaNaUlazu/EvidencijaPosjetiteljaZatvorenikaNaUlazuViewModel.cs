using System;
using System.Collections.Generic;
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
            EvidencijePosjetitelja = new List<EvidencijaPosjetiteljaJSONModel>();
            Evidencija = new DokumentDTO();

            DatumDolaska = DateTime.Now;
            DatumOdlaska = DateTime.Now;

            DohvatiPodatkeUEvidencijama();
        }

        #endregion

        #region Properties

        public List<EvidencijaPosjetiteljaJSONModel> EvidencijePosjetitelja { get; set; }

        public DokumentDTO Evidencija { get; set; }

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

        private string zatvorenik;
        public string Zatvorenik
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

        private DateTime? datumDolaska;
        public DateTime? DatumDolaska
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

        private DateTime? datumOdlaska;
        public DateTime? DatumOdlaska
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

        private void DohvatiPodatkeUEvidencijama()
        {
            Evidencija = App.client.DohvatiEvidenciju("", "E_PZU");
            if (Evidencija.DigitalniDokument != null)
            {
                List<EvidencijaPosjetiteljaJSONModel> evidencija = (List<EvidencijaPosjetiteljaJSONModel>)Newtonsoft.Json.JsonConvert.DeserializeObject(Evidencija.DigitalniDokument);
                EvidencijePosjetitelja = evidencija;
            }
        }


        private void UnesiEvidenciju()
        {
            EvidencijaPosjetiteljaJSONModel obj = new EvidencijaPosjetiteljaJSONModel();

            try
            {
                obj.ImePrezime = this.ImePrezime;
                obj.Napomena = this.Napomena;
                obj.Uloga = this.Uloga;
                obj.Zatvorenik = this.Zatvorenik;
                obj.DatumDolaska = this.DatumDolaska.Value.Add(VrijemeDolaska);
                obj.DatumOdlaska = this.DatumOdlaska.Value.Add(VrijemeOdlaska);

                EvidencijePosjetitelja.Add(obj);
                string jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(EvidencijePosjetitelja);

                Evidencija.DigitalniDokument = jsonObj;

                App.client.UnesiEvidenciju("", Evidencija);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Commands

        public ICommand UnesiCommand => new Command(() => UnesiEvidenciju());


        #endregion





    }
}
