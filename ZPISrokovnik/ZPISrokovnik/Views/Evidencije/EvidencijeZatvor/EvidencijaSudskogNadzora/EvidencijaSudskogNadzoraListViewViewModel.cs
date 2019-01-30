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
using ZPISrokovnik.Views.Evidencije.EvidencijaSudskogNadzora;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaSudskogNadzora
{
	public class EvidencijaSudskogNadzoraListViewViewModel : BaseViewModel
	{
        #region Constructor(s)

        public EvidencijaSudskogNadzoraListViewViewModel(IPageService page)
        {
            pageService = page;

            DohvatiEvidencije();
        }

        #endregion

        #region Properties

        private ObservableCollection<EvidencijaSudskogNadzoraJSONModel> evidencijeSudskogNadzora;
        public ObservableCollection<EvidencijaSudskogNadzoraJSONModel> EvidencijeSudskogNadzora
        {
            get
            {
                return evidencijeSudskogNadzora;
            }
            set
            {
                SetValue(ref evidencijeSudskogNadzora, value);
                OnPropertyChanged(nameof(EvidencijeSudskogNadzora));
            }
        }

        #endregion

        #region Command

        public ICommand NoviZapisCommand => new Command(() => NoviZapis());

        #endregion

        #region Methods

        private void NoviZapis()
        {
            pageService.PushAsync(new EvidencijaSudskogNadzoraView());
        }

        private async void DohvatiEvidencije()
        {
            var dokument = await Task.Factory.FromAsync(
                App.client.BeginDohvatiEvidenciju,
                App.client.EndDohvatiEvidenciju,
                "", "E_SN", TaskCreationOptions.None);

            if (dokument != null)
            {
                List<EvidencijaSudskogNadzoraJSONModel> evidencije = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EvidencijaSudskogNadzoraJSONModel>>(dokument.DigitalniDokument);

                EvidencijeSudskogNadzora = new ObservableCollection<EvidencijaSudskogNadzoraJSONModel>(evidencije);
            }
        }

        #endregion

        #region PageService

        IPageService pageService { get; set; }

        #endregion
    }
}