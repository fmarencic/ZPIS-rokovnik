using Xamarin.Forms;
using System.Windows.Input;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;
using System.Threading.Tasks;

namespace ZPISrokovnik.Views.MainView
{
    public class MainZatvorViewModel : BaseViewModel
	{
        #region Constructor
        public MainZatvorViewModel (IPageService page)
		{
            this.pageService = page;
            GetDataByUserInstance();
		}
        #endregion

        #region Properties
        private IPageService pageService;
        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetValue(ref searchText, value);
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private string caption;
        public string Caption
        {
            get { return caption; }
            set
            {
                SetValue(ref caption, value);
                OnPropertyChanged(nameof(Caption));
            }
        }

        private long? brojIstraznihZatvorenikaMuski;
        public long? BrojIstraznihZatvorenikaMuski
        {
            get { return brojIstraznihZatvorenikaMuski; }
            set
            {
                SetValue(ref brojIstraznihZatvorenikaMuski, value);
                OnPropertyChanged(nameof(BrojIstraznihZatvorenikaMuski));
            }
        }

        private long? brojIstraznihZatvorenikaZenski;
        public long? BrojIstraznihZatvorenikaZenski
        {
            get { return brojIstraznihZatvorenikaZenski; }
            set
            {
                SetValue(ref brojIstraznihZatvorenikaZenski, value);
                OnPropertyChanged(nameof(BrojIstraznihZatvorenikaZenski));
            }
        }

        private long? brojKaznjenikaMuski;
        public long? BrojKaznjenikaMuski
        {
            get { return brojKaznjenikaMuski; }
            set
            {
                SetValue(ref brojKaznjenikaMuski, value);
                OnPropertyChanged(nameof(BrojKaznjenikaMuski));
            }
        }

        private long? brojKaznjenikaZenski;
        public long? BrojKaznjenikaZenski
        {
            get { return brojKaznjenikaZenski; }
            set
            {
                SetValue(ref brojKaznjenikaZenski, value);
                OnPropertyChanged(nameof(BrojKaznjenikaZenski));
            }
        }

        private long? brojZatvorenikaMuski;
        public long? BrojZatvorenikaMuski
        {
            get { return brojZatvorenikaMuski; }
            set
            {
                SetValue(ref brojZatvorenikaMuski, value);
                OnPropertyChanged(nameof(BrojZatvorenikaMuski));
            }
        }

        private long? brojZatvorenikaZenski;
        public long? BrojZatvorenikaZenski
        {
            get { return brojZatvorenikaZenski; }
            set
            {
                SetValue(ref brojZatvorenikaZenski, value);
                OnPropertyChanged(nameof(BrojZatvorenikaZenski));
            }
        }

        private long? naIzlaskuMuski;
        public long? NaIzlaskuMuski
        {
            get { return naIzlaskuMuski; }
            set
            {
                SetValue(ref naIzlaskuMuski, value);
                OnPropertyChanged(nameof(NaIzlaskuMuski));
            }
        }

        private long? naIzlaskuZenski;
        public long? NaIzlaskuZenski
        {
            get { return naIzlaskuZenski; }
            set
            {
                SetValue(ref naIzlaskuZenski, value);
                OnPropertyChanged(nameof(NaIzlaskuZenski));
            }
        }

        private long? naPrekidMuski;
        public long? NaPrekidMuski
        {
            get { return naPrekidMuski; }
            set
            {
                SetValue(ref naPrekidMuski, value);
                OnPropertyChanged(nameof(NaPrekidMuski));
            }
        }

        private long? naPrekidZenski;
        public long? NaPrekidZenski
        {
            get { return naPrekidZenski; }
            set
            {
                SetValue(ref naPrekidZenski, value);
                OnPropertyChanged(nameof(NaPrekidZenski));
            }
        }

        private long? prolazniMuski;
        public long? ProlazniMuski
        {
            get { return prolazniMuski; }
            set
            {
                SetValue(ref prolazniMuski, value);
                OnPropertyChanged(nameof(ProlazniMuski));
            }
        }

        private long? prolazniZenski;
        public long? ProlazniZenski
        {
            get { return prolazniZenski; }
            set
            {
                SetValue(ref prolazniZenski, value);
                OnPropertyChanged(nameof(ProlazniZenski));
            }
        }

        private long? uBijeguMuski;
        public long? UBijeguMuski
        {
            get { return uBijeguMuski; }
            set
            {
                SetValue(ref uBijeguMuski, value);
                OnPropertyChanged(nameof(UBijeguMuski));
            }
        }

        private long? uBijeguZenski;
        public long? UBijeguZenski
        {
            get { return uBijeguZenski; }
            set
            {
                SetValue(ref uBijeguZenski, value);
                OnPropertyChanged(nameof(UBijeguZenski));
            }
        }
        #endregion

        #region Commands
        public ICommand SearchCommand => new Command(() => Search());
        #endregion

        #region Methods
        private void Search()
        {
            pageService.PushAsync(new MainSearch(SearchText));
        }

        private async void GetDataByUserInstance()
        {
            //BrojcanoStanjeDTO brojcanoStanje = null;//await App.client.VratiBrojcanoStanjeAsync(App.TijeloId, "");

            var brojcanoStanje = await Task.Factory.FromAsync(
                                  App.client.BeginVratiBrojcanoStanje,
                                  App.client.EndVratiBrojcanoStanje,
                                  App.TijeloId, "",
                                  TaskCreationOptions.None);


            DTOToObject(brojcanoStanje);
        }
        private void DTOToObject(BrojcanoStanjeDTO obj)
        {
            Caption = obj.NazivTijela;
            BrojIstraznihZatvorenikaMuski = obj.BrojIstraznihZatvorenikaMuski ?? null;
            BrojIstraznihZatvorenikaZenski = obj.BrojIstraznihZatvorenikaZenski ?? null;
            BrojKaznjenikaMuski = obj.BrojKaznjenikaMuski ?? null;
            BrojKaznjenikaZenski = obj.BrojKaznjenikaZenski ?? null;
            BrojZatvorenikaMuski = obj.BrojZatvorenikaMuski ?? null;
            BrojZatvorenikaZenski = obj.BrojZatvorenikaZenski ?? null;
            NaIzlaskuMuski = obj.NaIzlaskuMuski ?? null;
            NaIzlaskuZenski = obj.NaIzlaskuZenski ?? null;
            NaPrekidMuski = obj.NaPrekidMuski ?? null;
            NaPrekidZenski = obj.NaPrekidZenski ?? null;
            ProlazniMuski = obj.ProlazniMuski ?? null;
            ProlazniZenski = obj.ProlazniZenski ?? null;
            UBijeguMuski = obj.UBijeguMuski ?? null;
            UBijeguZenski = obj.UBijeguZenski ?? null;
        }
        #endregion
    }
}