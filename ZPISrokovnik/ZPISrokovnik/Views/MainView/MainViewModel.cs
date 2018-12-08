using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainViewModel : BaseViewModel
	{
        #region Constructor
        public MainViewModel (IPageService page)
		{
            this.pageService = page;
            SearchCommand = new Command(Search);
		}
        #endregion

        #region Properties
        string caption = "Zatvor u Zagrebu";
        private IPageService pageService;
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public Command SearchCommand { get; private set; }
        #endregion

        #region Methods
        private void Search()
        {
            pageService.PushAsync(new MainSearch());
        }
        #endregion
    }
}