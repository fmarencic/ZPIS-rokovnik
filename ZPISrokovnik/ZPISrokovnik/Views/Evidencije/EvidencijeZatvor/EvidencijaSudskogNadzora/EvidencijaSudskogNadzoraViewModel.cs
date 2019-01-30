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
    public class EvidencijaSudskogNadzoraViewModel : BaseViewModel
    {
        #region Constructor(s)

        public EvidencijaSudskogNadzoraViewModel(IPageService page)
        {
            EvidencijeSudskogNadzora = new List<EvidencijaSudskogNadzoraJSONModel>();
            Evidencija = new DokumentDTO();

            Sudovi = new ObservableCollection<OsobaDTO>();

            pageService = page;

            DohvatiPodatkeUEvidencijama();
            DohvatiSudove();

            Datum = DateTime.Now;

        }

        #endregion

        #region Properties

        public List<EvidencijaSudskogNadzoraJSONModel> EvidencijeSudskogNadzora { get; set; }
        public DokumentDTO Evidencija { get; set; }

        private OsobaDTO sud;
        public OsobaDTO Sud
        {
            get
            {
                return sud;
            }
            set
            {
                SetValue(ref sud, value);
                OnPropertyChanged(nameof(Sud));
            }
        }

        private DateTime datum;
        public DateTime Datum
        {
            get
            {
                return datum;
            }
            set
            {
                SetValue(ref datum, value);
                OnPropertyChanged(nameof(Datum));
            }
        }

        private TimeSpan od;
        public TimeSpan Od
        {
            get
            {
                return od;
            }
            set
            {
                SetValue(ref od, value);
                OnPropertyChanged(nameof(Od));
            }
        }

        private TimeSpan _do;
        public TimeSpan Do
        {
            get
            {
                return _do;
            }
            set
            {
                SetValue(ref _do, value);
                OnPropertyChanged(nameof(Do));
            }
        }

        private ObservableCollection<OsobaDTO> sudovi;
        public ObservableCollection<OsobaDTO> Sudovi
        {
            get
            {
                return sudovi;
            }
            set
            {
                SetValue(ref sudovi, value);
                OnPropertyChanged(nameof(Sudovi));
            }
        }

        #endregion

        #region PageService

        private readonly IPageService pageService;

        #endregion

        #region Methods

        private void DohvatiPodatkeUEvidencijama()
        {
            Evidencija = App.client.DohvatiEvidenciju("", "E_SN");
            if (Evidencija.DigitalniDokument != null)
            {
                List<EvidencijaSudskogNadzoraJSONModel> evidencija = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EvidencijaSudskogNadzoraJSONModel>>(Evidencija.DigitalniDokument);
                EvidencijeSudskogNadzora = evidencija;
            }
        }

        private void UnesiEvidenciju()
        {
            EvidencijaSudskogNadzoraJSONModel obj = new EvidencijaSudskogNadzoraJSONModel();

            try
            {
                obj.Sud = this.Sud;
                obj.Datum = this.Datum;
                obj.Od = this.Od;
                obj.Do = this.Do;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            EvidencijeSudskogNadzora.Add(obj);
            string jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(EvidencijeSudskogNadzora);

            Evidencija.DigitalniDokument = jsonObj;
            App.client.UnesiEvidenciju("", Evidencija);
        }

        private async void DohvatiSudove()
        {
            var sudovi = await Task.Factory.FromAsync(
                App.client.BeginVratiSudove,
                App.client.EndVratiSudove,
                "", TaskCreationOptions.None);

            if (sudovi != null)
            {
                foreach (var item in sudovi)
                {
                    OsobaDTO o = item as OsobaDTO;
                    Sudovi.Add(o);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand UnesiCommand => new Command(() => UnesiEvidenciju());


        #endregion
    }
}
