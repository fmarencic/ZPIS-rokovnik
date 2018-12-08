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
		public MainViewModel (IPageService page)
		{
            this.pageService = page;
            SearchCommand = new Command(Search);
		}

        string caption = "Zatvor u Zagrebu";
        private IPageService pageService;

        public Command SearchCommand { get; private set; }

        public string Caption
        {
            get { return caption; }
            set {
                caption = value;
                OnPropertyChanged();
            }
        }

        private void Search()
        {
            pageService.PushAsync(new MainSearch());
        }
	}
}