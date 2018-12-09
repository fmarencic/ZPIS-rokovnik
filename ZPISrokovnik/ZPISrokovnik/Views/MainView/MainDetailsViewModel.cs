using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainDetailsViewModel : BaseViewModel
	{
        #region Constructor
        public MainDetailsViewModel (IPageService page)
		{
            this.pageService = page;
		}
        #endregion

        #region Properties
        private string caption = "Podaci o osobi";
        private IPageService pageService;

        public string Caption
        {
            get { return caption; }
            set {
                caption = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}