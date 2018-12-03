using System.Windows.Input;
using Xamarin.Forms;
//using ZPISdatabaseAzure;
//using ZPISdatabaseAzure.Model;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views
{
    public class LoginViewModel : BaseViewModel
    {

        #region Contructor(s)

        public LoginViewModel(ILoginPageService page)
        {
            this.LogInCommand = new Command(LogIn);
            this.pageService = page;
        }

        #endregion

        #region Properties

        private string korisnickoIme;
        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }
            set
            {
                SetValue(ref korisnickoIme, value);
                OnPropertyChanged(nameof(KorisnickoIme));
            }
        }

        private string lozinka;
        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                SetValue(ref lozinka, value);
                OnPropertyChanged(nameof(Lozinka));
            }
        }

        private long tijeloId;
        public long TijeloId
        {
            get
            {
                return tijeloId;
            }
            set
            {
                SetValue(ref tijeloId, value);
                OnPropertyChanged(nameof(TijeloId));
            }
        }

        #endregion

        #region Commands

        public ICommand LogInCommand { get; private set; }

        #endregion

        #region PageService

        private readonly ILoginPageService pageService;

        #endregion

        #region Methods

        private void LogIn()
        {
            //IKorisnikRepozitorij rep = new KorisnikRepozitorij(new ZPISRokovnikDatabaseContext());
            //KorisnikEF korisnikEF = rep.LogIn(KorisnickoIme, Lozinka);
            KorisnickoIme = "Korisničko ime";
            Lozinka = "Lozinka";

            App.IsUserLoggedIn = true;

            pageService.PushAfterLogin(new MainTabbedPage());
        }

        #endregion

    }
}
