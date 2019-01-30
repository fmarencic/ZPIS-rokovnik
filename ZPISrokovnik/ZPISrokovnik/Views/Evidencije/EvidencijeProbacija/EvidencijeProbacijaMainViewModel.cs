using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeProbacija
{
	public class EvidencijeProbacijaMainViewModel : BaseViewModel
	{
        #region Constructor(s)

        public EvidencijeProbacijaMainViewModel(IPageService page)
        {
            UpisniciProbacija = new ObservableCollection<ProbacijaUpisnikDTO>();

            DohvatiUpisnike();
        }

        #endregion

        #region Properties

        private ObservableCollection<ProbacijaUpisnikDTO> upisniciProbacija;
        public ObservableCollection<ProbacijaUpisnikDTO> UpisniciProbacija
        {
            get
            {
                return upisniciProbacija;
            }
            set
            {
                SetValue(ref upisniciProbacija, value);
                OnPropertyChanged(nameof(UpisniciProbacija));
            }
        }

        #endregion

        #region Methods

        public async void DohvatiUpisnike()
        {
            var upisnici = await Task.Factory.FromAsync(
                App.client.BeginDohvatiProbacijskeUpisnike,
                App.client.EndDohvatiProbacijskeUpisnike,
                "", TaskCreationOptions.None);

            if (upisnici != null)
            {
                foreach (var item in upisnici)
                {
                    ProbacijaUpisnikDTO o = item as ProbacijaUpisnikDTO;
                    UpisniciProbacija.Add(o);
                }
            }
        }

        #endregion


    }
}