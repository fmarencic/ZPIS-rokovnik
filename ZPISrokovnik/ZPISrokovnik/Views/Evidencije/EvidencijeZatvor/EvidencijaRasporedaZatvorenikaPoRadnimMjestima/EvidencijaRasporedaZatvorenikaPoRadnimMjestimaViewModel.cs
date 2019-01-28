using System;
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

            pageService = page;
            DohvatiRadnaMjesta();
        }

        #endregion

        #region Properties

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

            string jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
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
                    DomenaDTO rm = App.client.DohvatiDomenu("", item.Id);
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
