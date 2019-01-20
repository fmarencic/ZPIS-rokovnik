using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.ValidationRules;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views
{
    public class LoginViewModel : BaseViewModel
    {    
        #region Contructor(s)

        public LoginViewModel(ILoginPageService page)
        {
            Lozinka = new ValidatableObject<string>();
            KorisnickoIme = new ValidatableObject<string>();

            pageService = page;

            UneseniIspravniPodaci = false;
        }

        #endregion

        #region ValidationRules

        private void AddValidation()
        {
            korisnickoIme.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Korisničko ime je obavezno."
            });
            lozinka.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Lozinka je obavezna."
            });
        }

        #endregion

        #region Properties

        private ValidatableObject<string> korisnickoIme;
        public ValidatableObject<string> KorisnickoIme
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

        private ValidatableObject<string> lozinka;
        public ValidatableObject<string> Lozinka
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

        private ObservableCollection<KeyValuePair<long, string>>  tijela;

        public ObservableCollection<KeyValuePair<long, string>> Tijela
        {
            get
            {
                return tijela;
            }
            set
            {
                SetValue(ref tijela, value);
                OnPropertyChanged(nameof(Tijela));
            }
        }

        private KeyValuePair<long, string> selectedItem;
        public KeyValuePair<long, string> SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                SetValue(ref selectedItem, value);
                if(value.Value != null)
                    UneseniIspravniPodaci = true;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private bool uneseniIspravniPodaci;
        public bool UneseniIspravniPodaci
        {
            get
            {
                return uneseniIspravniPodaci;
            }
            set
            {
                SetValue(ref uneseniIspravniPodaci, value);
                OnPropertyChanged(nameof(UneseniIspravniPodaci));
            }
        }

        private bool postojeKorisnickeInstance;
        public bool PostojeKorisnickeInstance
        {
            get
            {
                return postojeKorisnickeInstance;
            }
            set
            {
                SetValue(ref postojeKorisnickeInstance, value);
                OnPropertyChanged(nameof(PostojeKorisnickeInstance));
            }
        }

        #endregion

        #region Commands

        public ICommand DohvatiKorisnickeInstanceCommand => new Command(() => DohvatiKorisnickeInstance());
        public ICommand LoginCommand => new Command(() => OnLogin());
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        #endregion

        #region PageService

        private readonly ILoginPageService pageService;

        #endregion

        #region Methods

        private void DohvatiKorisnickeInstance()
        {
            Osvjezi();
            Dohvati();
        }

        private void Osvjezi()
        {
            if (Tijela != null)
            {
                Tijela.Clear();
                PostojeKorisnickeInstance = false;
            }
        }

        private void Dohvati()
        {
            if (KorisnickoIme.Value != null)
            {
                KorisnikDTO korisnik = App.client.GetKorisnikByUsername(KorisnickoIme.Value, "");
                if (korisnik != null)
                {
                    Tijela = new ObservableCollection<KeyValuePair<long, string>>(VratiListuSudovaSaKorisnika(korisnik));
                    PostojeKorisnickeInstance = true;
                }
            }
        }

        public List<KeyValuePair<long, string>> VratiListuSudovaSaKorisnika(KorisnikDTO k)
        {
            try
            {

                string[] tijela = k.ZaposlenNaTijelima.Split(';');

                var l = new List<KeyValuePair<long, string>>();

                foreach (var t in tijela)
                {
                    var tijelo = t.Split('/');
                    l.Add(new KeyValuePair<long, string>(long.Parse(tijelo[0]), tijelo[1]));
                }
                return l;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnLogin()
        {
            var login = App.client.LoginUser(KorisnickoIme.Value, Lozinka.Value);

            if (!(string.IsNullOrEmpty(login.Token)))
            {          
                if (SelectedItem.Value != null)
                {
                    App.Token = login.Token;
                    App.TijeloId = SelectedItem.Key;
                    pageService.PushAfterLogin(new MainTabbedPage());
                }
            }
            else
                pageService.DisplayAlert("Prijava neuspješna", "Netočno korisničko ime ili lozinka", "U redu", "Odustani");
        }

        private bool ValidateUserName()
        {
            return korisnickoIme.Validate();
        }

        private bool ValidatePassword()
        {
            return lozinka.Validate();
        }




        #endregion

    }
}
