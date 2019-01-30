
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