using System;
using System.Collections.ObjectModel;
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
            GetData();
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
        private void GetData()
        {
            PrikazMaticeDTO[] matica = App.client.DohvatiMaticu("", ForwardedObject.OIB);
            ShowData(matica);
        }
        private void ShowData(PrikazMaticeDTO[] matica)
        {
            OsobaInfo = new ObservableCollection<Osoba>();
            OsobaInfo.Add(new Osoba { NaslovObiljezja="Ime i prezime", VrijednostObiljezja=String.Concat(ForwardedObject.Ime, " ", ForwardedObject.Prezime) });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "Adresa", VrijednostObiljezja = ForwardedObject.Adresa });
            OsobaInfo.Add(new Osoba { NaslovObiljezja = "OIB", VrijednostObiljezja = ForwardedObject.OIB });
            for(int i = 0; i < matica.Length; i++)
            {
                OsobaInfo.Add(new Osoba { NaslovObiljezja = "Kazneno djelo", VrijednostObiljezja = matica[i].OznakaPredmeta });
                OsobaInfo.Add(new Osoba { NaslovObiljezja = "Presuda", VrijednostObiljezja = matica[i].StatusPredmeta });
            }
        }
        #endregion
    }
}