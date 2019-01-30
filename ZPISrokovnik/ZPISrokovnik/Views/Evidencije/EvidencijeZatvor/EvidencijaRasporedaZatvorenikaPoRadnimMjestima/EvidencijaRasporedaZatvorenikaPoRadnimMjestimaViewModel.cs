using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.JSONModel;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.Evidencije
{
    public class EvidencijaRasporedaZatvorenikaPoRadnimMjestimaViewModel : BaseViewModel
    {
        #region Constructor(s)

        public EvidencijaRasporedaZatvorenikaPoRadnimMjestimaViewModel(IPageService page)
        {
            RadnaMjesta = new ObservableCollection<DomenaDTO>();
            EvidencijeRasporeda = new List<EvidencijaRasporedaZatvorenikaJSONModel>();
            Evidencija = new DokumentDTO();

            pageService = page;

            DohvatiPodatkeUEvidencijama();
            DohvatiRadnaMjesta();

            DatumRadDo = DateTime.Now;
            DatumRadOd = DateTime.Now;
            DatumRasporeda = DateTime.Now;
        }

        #endregion

        #region Properties

        public List<EvidencijaRasporedaZatvorenikaJSONModel> EvidencijeRasporeda { get; set; }

        public DokumentDTO Evidencija { get; set; }

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

        private DomenaDTO radnoMjesto;
        public DomenaDTO RadnoMjesto
        {
            get
            {
                return radnoMjesto;
            }
            set
            {
                SetValue(ref radnoMjesto, value);
                OnPropertyChanged(nameof(RadnoMjesto));
            }
        }

        private DateTime? datumRadOd;
        public DateTime? DatumRadOd
        {
            get
            {
                return datumRadOd;
            }
            set
            {
                SetValue(ref datumRadOd, value);
                OnPropertyChanged(nameof(DatumRadOd));
            }
        }

        private DateTime? datumRadDo;
        public DateTime? DatumRadDo
        {
            get
            {
                return datumRadDo;
            }
            set
            {
                SetValue(ref datumRadDo, value);
                OnPropertyChanged(nameof(DatumRadDo));
            }
        }

        private DateTime? datumRasporeda;
        public DateTime? DatumRasporeda
        {
            get
            {
                return datumRasporeda;
            }
            set
            {
                SetValue(ref datumRasporeda, value);
                OnPropertyChanged(nameof(DatumRasporeda));
            }
        }

        private ObservableCollection<DomenaDTO> radnaMjesta;
        public ObservableCollection<DomenaDTO> RadnaMjesta
        {
            get
            {
                return radnaMjesta;
            }
            set
            {
                SetValue(ref radnaMjesta, value);
                OnPropertyChanged(nameof(RadnaMjesta));
            }
        }

        #endregion

        #region PageService

        private readonly IPageService pageService;

        #endregion

        #region Methods

        private async Task DohvatiPodatkeUEvidencijama()
        {
            //Evidencija = App.client.DohvatiEvidenciju("", "E_RM");
            Evidencija = await Task.Factory.FromAsync(
                                  App.client.BeginDohvatiEvidenciju,
                                  App.client.EndDohvatiEvidenciju,
                                  "", "E_RM",
                                  TaskCreationOptions.None);
            if (Evidencija.DigitalniDokument != null)
            {
                List<EvidencijaRasporedaZatvorenikaJSONModel> evidencija = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EvidencijaRasporedaZatvorenikaJSONModel>>(Evidencija.DigitalniDokument);
                EvidencijeRasporeda = evidencija;
            }
        }

        private void UnesiEvidenciju()
        {
            EvidencijaRasporedaZatvorenikaJSONModel obj = new EvidencijaRasporedaZatvorenikaJSONModel();

            try
            {
                obj.Zatvorenik = this.Zatvorenik;
                obj.RadnoMjesto = this.RadnoMjesto;
                obj.DatumRadOd = this.DatumRadOd;
                obj.DatumRadDo = this.DatumRadDo;
                obj.DatumRasporeda = this.DatumRasporeda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            EvidencijeRasporeda.Add(obj);
            string jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(EvidencijeRasporeda);

            Evidencija.DigitalniDokument = jsonObj;
            App.client.UnesiEvidenciju("", Evidencija);
        }

        private async void DohvatiRadnaMjesta()
        {
            var radnaMjesta = await Task.Factory.FromAsync(
                App.client.BeginDohvatiRadnaMjesta,
                App.client.EndDohvatiRadnaMjesta,
                "", TaskCreationOptions.None);

            if (radnaMjesta != null)
            {
                foreach (var item in radnaMjesta)
                {
                    DomenaDTO rm = item as DomenaDTO;
                    RadnaMjesta.Add(rm);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand UnesiCommand => new Command(() => UnesiEvidenciju());


        #endregion
    }
}
