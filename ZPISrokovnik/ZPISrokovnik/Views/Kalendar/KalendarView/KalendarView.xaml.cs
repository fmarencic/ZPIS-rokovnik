using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Kalendar.KalendarView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KalendarView : ContentPage
	{
		public KalendarView ()
		{
			InitializeComponent ();
            this.BindingContext = new KalendarViewModel(new PageService());
		    //ElementListe.ItemsSource = App.DatabaseController.DohvatiSveNapomene();
		}


	    private void Uredi_OnClicked(object sender, EventArgs e)
	    {
	        var viewModel = this.BindingContext as KalendarViewModel;
            viewModel?.UrediNapomenuCommand.Execute(null);
            
	    }

	    private void Obrisi_OnClicked(object sender, EventArgs e)
	    {
	        var viewModel = this.BindingContext as KalendarViewModel;
	        viewModel?.ObrisiNapomenuCommand.Execute(null);
        }
	}
}