using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.MainView
{
	public class MainDetailsViewModel : BaseViewModel
	{
        #region Constructor
        public MainDetailsViewModel (IPageService page, OsobaDTO obj)
		{
            this.pageService = page;
            ForwardedObject = obj;
            ShowData();
		}
        #endregion

        #region Properties
        private IPageService pageService;

        private string caption = "Podaci o osobi";
        public string Caption
        {
            get { return caption; }
            set {
                caption = value;
                OnPropertyChanged();
            }
        }

        private OsobaDTO forwardedObject;
        public OsobaDTO ForwardedObject
        {
            get { return forwardedObject; }
            set
            {
                SetValue(ref forwardedObject, value);
                OnPropertyChanged(nameof(ForwardedObject));
            }
        }

        private ObservableCollection<Osoba> osobaInfo;
        public ObservableCollection<Osoba> OsobaInfo
        {
            get { return osobaInfo; }
            set
            {
                SetValue(ref osobaInfo, value);
                OnPropertyChanged(nameof(OsobaInfo));
            }
        }
        #endregion

        #region Methods
        private void ShowData()
        {
            OsobaInfo = new ObservableCollection<Osoba>();
            OsobaInfo.Add(new Osoba { NaslovObiljezja="Ime i prezime", VrijednostObiljezja=String.Concat(ForwardedObject.Ime, " ", ForwardedObject.Prezime) });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "Datum rođenja", VrijednostObiljezja = ForwardedObject.DatumRodenja.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture) });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "Adresa", VrijednostObiljezja = ForwardedObject.Adresa });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "OIB", VrijednostObiljezja = ForwardedObject.OIB });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "Kazneno djelo", VrijednostObiljezja = "" });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "Presuda", VrijednostObiljezja = "" });
        }
        #endregion
    }
}