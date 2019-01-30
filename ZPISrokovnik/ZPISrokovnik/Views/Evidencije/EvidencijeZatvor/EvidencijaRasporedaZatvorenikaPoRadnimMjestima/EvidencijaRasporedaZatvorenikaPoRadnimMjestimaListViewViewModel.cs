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
using ZPISrokovnik.Views.Evidencije.EvidencijaRasporedaZatvorenikaPoRadnimMjestima;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaRasporedaZatvorenikaPoRadnimMjestima
{
	public class EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListViewViewModel : BaseViewModel
	{
        #region Constructor(s)

        public EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListViewViewModel(IPageService page)
        {
            pageService = page;

            DohvatiEvidencije();
        }

        #endregion

        #region Properties

        private ObservableCollection<EvidencijaRasporedaZatvorenikaJSONModel> evidencijeRasporeda;
        public ObservableCollection<EvidencijaRasporedaZatvorenikaJSONModel> EvidencijeRasporeda
        {
            get
            {
                return evidencijeRasporeda;
            }
            set
            {
                SetValue(ref evidencijeRasporeda, value);
                OnPropertyChanged(nameof(EvidencijeRasporeda));
            }
        }

        #endregion

        #region Command

        public ICommand NoviZapisCommand => new Command(() => NoviZapis());

        #endregion

        #region Methods

        private void NoviZapis()
        {
            pageService.PushAsync(new EvidencijaRasporedaZatvorenikaPoRadnimMjestimaView());
        }

        private async void DohvatiEvidencije()
        {
            var dokument = await Task.Factory.FromAsync(
                App.client.BeginDohvatiEvidenciju,
                App.client.EndDohvatiEvidenciju,
                "", "E_RM", TaskCreationOptions.None);

            if (dokument != null)
            {
                List<EvidencijaRasporedaZatvorenikaJSONModel> evidencije = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EvidencijaRasporedaZatvorenikaJSONModel>>(dokument.DigitalniDokument);

                EvidencijeRasporeda = new ObservableCollection<EvidencijaRasporedaZatvorenikaJSONModel>(evidencije);
            }
        }

        #endregion

        #region PageService

        IPageService pageService { get; set; }

        #endregion
    }
}