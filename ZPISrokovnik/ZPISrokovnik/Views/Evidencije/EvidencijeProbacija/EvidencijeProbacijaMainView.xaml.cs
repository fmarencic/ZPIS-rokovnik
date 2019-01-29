using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeProbacija
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijeProbacijaMainView : ContentPage
	{
		public EvidencijeProbacijaMainView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijeProbacijaMainViewModel(new PageService());
		}
	}
}