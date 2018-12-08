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
		public MainDetailsViewModel (IPageService page)
		{
            this.pageService = page;
		}

        private IPageService pageService;
	}
}