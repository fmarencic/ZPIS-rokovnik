
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Evidencije.EvidencijeZatvor.EvidencijaPosjetiteljaZatvorenicimaNaUlazu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvidencijaPosjetiteljaZatvorenikaNaUlazuListView : ContentPage
	{
		public EvidencijaPosjetiteljaZatvorenikaNaUlazuListView ()
		{
			InitializeComponent ();
            this.BindingContext = new EvidencijaPosjetiteljaZatvorenikaNaUlazuListViewViewModel(new PageService());
        }
	}
}