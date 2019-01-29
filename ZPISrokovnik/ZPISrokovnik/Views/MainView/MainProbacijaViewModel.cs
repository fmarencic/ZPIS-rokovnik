using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainProbacijaViewModel : BaseViewModel
	{
        #region Constructor
        public MainProbacijaViewModel(IPageService page)
        {
            this.pageService = page;
        }
        #endregion

        #region Properties
        private IPageService pageService;
        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetValue(ref searchText, value);
                OnPropertyChanged(nameof(SearchText));
            }
        }
        #endregion

        #region Commands
        public ICommand SearchCommand => new Command(() => Search());
        #endregion

        #region Methods
        private void Search()
        {
            pageService.PushAsync(new MainSearch(SearchText));
        }
        #endregion
    }
}