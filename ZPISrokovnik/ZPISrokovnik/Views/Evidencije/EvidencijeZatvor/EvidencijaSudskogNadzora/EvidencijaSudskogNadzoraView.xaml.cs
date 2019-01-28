using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijaSudskogNadzora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijaSudskogNadzoraView : ContentPage
	{
		public EvidencijaSudskogNadzoraView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijaSudskogNadzoraViewModel(new PageService());
		}
	}
}