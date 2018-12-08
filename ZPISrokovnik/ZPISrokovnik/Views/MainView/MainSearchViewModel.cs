using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainSearchViewModel : BaseViewModel
	{
        #region Constructor
        public MainSearchViewModel (IPageService page)
		{
            this.pageService = page; 
		}
        #endregion

        #region Properties
        private string caption = "Zatvor u Zagrebu";
        private string captionImeIPrezime = "Ime i prezime";
        private string captionOIB = "OIB";
        private string captionGodinaRodjenja = "Datum rođenja";
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

        public string CaptionGodinaRodjenja {
            get { return captionGodinaRodjenja; }
            set { captionGodinaRodjenja = value; }
        }
        public string CaptionOIB {
            get { return captionOIB; }
            set { captionOIB = value; }
        }
        public string CaptionImeIPrezime {
            get { return captionImeIPrezime; }
            set { captionImeIPrezime = value; }
        }
        #endregion

        #region Commands
        public Command DetailsCommand { get; private set; }
        #endregion
    }
}