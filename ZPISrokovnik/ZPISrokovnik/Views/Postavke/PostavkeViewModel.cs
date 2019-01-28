using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZpisRokovnikService.DataLayer;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Postavke
{
    public class PostavkeViewModel : BaseViewModel
    {
        public ICommand OdjavaCommand => new Command(Odjava);

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

        private string korisnickaOznaka;
        public string KorisnickaOznaka
        {
            get { return korisnickaOznaka; }
            set
            {
                SetValue(ref korisnickaOznaka, value);
                OnPropertyChanged(nameof(KorisnickaOznaka));
            }
        }

        public PostavkeViewModel()
        {
            DohvatiOsobu();
            DohvatiKorisnickuOznaku();
            this.IsToggled = (bool)Application.Current.Properties.ContainsKey("Obavjesti");
        }

        private void DohvatiOsobu()
        {
            this.KorisnickoIme = App.KorisnickoIme;
        }

        private void DohvatiKorisnickuOznaku()
        {
            this.korisnickaOznaka = App.KorisnickaOznaka;
        }


        private void Odjava()
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }

        private bool isToggled;

        public bool IsToggled
        {
            get { return isToggled; }
            set
            {
                SetValue(ref (isToggled), value);
                OnPropertyChanged(nameof(IsToggled));
                PostaviObavjest();
            }
        }
        private async void PostaviObavjest()
        {
            Application.Current.Properties["Obavjesti"] = this.IsToggled;
            await Application.Current.SavePropertiesAsync();
        }
    }
}