using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Evidencije.EvidencijaRasporedaZatvorenikaPoRadnimMjestima;
using ZPISrokovnik.Views.Evidencije.EvidencijaSudskogNadzora;
using ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaPosjetiteljaZatvorenicimaNaUlazu;
using ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaRasporedaZatvorenikaPoRadnimMjestima;
using ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaSudskogNadzora;

namespace ZPISrokovnik.Views.Evidencije
{
    public class EvidencijeZatvorMainViewModel : BaseViewModel
    {
        #region Conustructor(s)

        public EvidencijeZatvorMainViewModel(IPageService page)
        {
            pageService = page;
        }

        #endregion

        #region Commands()

        public ICommand OtvoriEvidencijuPosjetiteljaCommand => new Command(() => OtvoriEvidencijuPosjetitelja());
        public ICommand OtvoriEvidencijuRasporedaZatvorenikaPoRadnimMjestimaCommand => new Command(() => OtvoriEvidencijuRasporedaZatvorenikaPoRadnimMjestima());
        public ICommand OtvorEvidencijuSudskogNadzoraCommand => new Command(() => OtvorEvidencijuSudskogNadzora());

        #endregion

        #region PageService

        private readonly IPageService pageService;

        #endregion


        #region Methods

        private void OtvoriEvidencijuPosjetitelja()
        {
            pageService.PushAsync(new EvidencijaPosjetiteljaZatvorenikaNaUlazuListView());
        }

        private void OtvoriEvidencijuRasporedaZatvorenikaPoRadnimMjestima()
        {
            pageService.PushAsync(new EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListView());
        }

        private void OtvorEvidencijuSudskogNadzora()
        {
            pageService.PushAsync(new EvidencijaSudskogNadzoraListView());
        }

        #endregion
    }
}
