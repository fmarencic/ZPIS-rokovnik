using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Evidencije.EvidencijaPosjetiteljaZatvorenicimaNaUlazu;

namespace ZPISrokovnik.Views.Evidencije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijaPosjetiteljaZatvorenicimaNaUlazuView : ContentPage
	{
		public EvidencijaPosjetiteljaZatvorenicimaNaUlazuView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijaPosjetiteljaZatvorenikaNaUlazuViewModel(new PageService());
        }
	}
}