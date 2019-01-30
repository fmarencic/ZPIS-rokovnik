using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.JSONModel;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaPosjetiteljaZatvorenicimaNaUlazu
{
	public class EvidencijaPosjetiteljaZatvorenikaNaUlazuListViewViewModel : BaseViewModel
	{

        #region Constructor(s)

        public EvidencijaPosjetiteljaZatvorenikaNaUlazuListViewViewModel(IPageService page)
        {
            pageService = page;

            DohvatiEvidencije();
        }

        #endregion

        #region Properties

        private ObservableCollection<EvidencijaPosjetiteljaJSONModel> evidencijePosjetitelja;
        public ObservableCollection<EvidencijaPosjetiteljaJSONModel> EvidencijePosjetitelja
        {
            get
            {
                return evidencijePosjetitelja;
            }
            set
            {
                SetValue(ref evidencijePosjetitelja, value);
                OnPropertyChanged(nameof(EvidencijePosjetitelja));
            }
        }

        #endregion

        #region Command

        public ICommand NoviZapisCommand => new Command(() => NoviZapis());

        #endregion

        #region Methods

        private void NoviZapis()
        {
            pageService.PushAsync(new EvidencijaPosjetiteljaZatvorenicimaNaUlazuView());
        }

        private async void DohvatiEvidencije()
        {
            var dokument = await Task.Factory.FromAsync(
                App.client.BeginDohvatiEvidenciju,
                App.client.EndDohvatiEvidenciju,
                "", "E_PZU", TaskCreationOptions.None);

            if (dokument != null)
            {
                List<EvidencijaPosjetiteljaJSONModel> evidencije = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EvidencijaPosjetiteljaJSONModel>>(dokument.DigitalniDokument);

                EvidencijePosjetitelja = new ObservableCollection<EvidencijaPosjetiteljaJSONModel>(evidencije);
            }
        }

        #endregion

        #region PageService

        IPageService pageService { get; set; }

        #endregion


    }
}