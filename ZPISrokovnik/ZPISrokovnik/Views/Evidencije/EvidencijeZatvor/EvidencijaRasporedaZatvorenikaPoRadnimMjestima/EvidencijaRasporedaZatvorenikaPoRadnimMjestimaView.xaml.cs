using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijaRasporedaZatvorenikaPoRadnimMjestima
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijaRasporedaZatvorenikaPoRadnimMjestimaView : ContentPage
	{
		public EvidencijaRasporedaZatvorenikaPoRadnimMjestimaView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijaRasporedaZatvorenikaPoRadnimMjestimaViewModel(new PageService());
		}
	}
}