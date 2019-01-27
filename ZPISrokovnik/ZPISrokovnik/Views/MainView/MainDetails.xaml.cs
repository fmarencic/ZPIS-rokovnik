using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.Views.MainView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainDetails : ContentPage
	{
		public MainDetails (OsobaDTO obj)
		{
			InitializeComponent ();
            BindingContext = new MainDetailsViewModel(new PageService(), obj);
		}
	}
}