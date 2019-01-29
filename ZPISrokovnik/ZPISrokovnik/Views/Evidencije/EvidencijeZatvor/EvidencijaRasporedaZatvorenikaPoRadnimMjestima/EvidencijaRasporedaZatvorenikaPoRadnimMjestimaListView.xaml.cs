using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaRasporedaZatvorenikaPoRadnimMjestima
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListView : ContentPage
	{
		public EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijaRasporedaZatvorenikaPoRadnimMjestimaListViewViewModel(new PageService());
		}
	}
}