using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Input;
using Xamarin.Forms;
//using ZPISdatabaseAzure;
//using ZPISdatabaseAzure.Model;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views
{
    public class LoginViewModel : BaseViewModel
    {
        private Service1Client Client;

        static BasicHttpBinding CreateBasicHttpBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            //TimeSpan timeout = new TimeSpan(0, 0, 30);
            //binding.SendTimeout = timeout;
            //binding.OpenTimeout = timeout;
            //binding.ReceiveTimeout = timeout;
            return binding;
        }

        #region Contructor(s)

        public LoginViewModel(ILoginPageService page)
        {
            LogInCommand = new Command(LogIn);

            EndpointAddress Endpoint = new EndpointAddress("http://zpiscloudservice.cloudapp.net/Service1.svc");

            Client = new Service1Client(CreateBasicHttpBinding(), Endpoint);
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
            OnLogin();


            pageService.PushAfterLogin(new MainTabbedPage());
        }

        private void OnLogin()
        {
            var login = Client.LoginUser(KorisnickoIme, Lozinka);

            KorisnikDTO korisnik = Client.GetKorisnikByUsername(KorisnickoIme, login.Token);
        }


        //public List<KeyValuePair<long, string>> VratiListuSudovaSaKorisnika(KorisnikDTO k)
        //{
        //    try
        //    {

        //        string[] tijela = k.osoba.Split(';');

        //        var l = new List<KeyValuePair<long, string>>();

        //        foreach (var t in tijela)
        //        {
        //            var tijelo = t.Split('/');
        //            l.Add(new KeyValuePair<long, string>(long.Parse(tijelo[0]), tijelo[1]));
        //        }
        //        return l;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

    }
}
