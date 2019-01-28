using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijeZatvorMainView : ContentPage
	{
		public EvidencijeZatvorMainView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijeZatvorMainViewModel(new PageService());
		}
	}
}