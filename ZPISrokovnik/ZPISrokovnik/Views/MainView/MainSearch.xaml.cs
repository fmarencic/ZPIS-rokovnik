using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainSearch : ContentPage
	{
		public MainSearch (string search)
		{
			InitializeComponent ();
            BindingContext = new MainSearchViewModel(new PageService(), search);
		}
	}
}