using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views.Kalendar.KalendarView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KalendarView : ContentPage
	{
	    public NapomenaModel OznaceniDogadaj { get; set; }
		public KalendarView ()
		{
			InitializeComponent ();
            this.BindingContext = new NapomenaModel();
		    ElementListe.ItemsSource = App.DatabaseController.DohvatiSveNapomene();
		}

        private async void DodajNovuNapomenu_OnPressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UnesiNapomenuView());
        }

	    private void ElementListe_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        if(OznaceniDogadaj != null)
	        {
	            OznaceniDogadaj.Vidljivo = false;
	        }
	        var vm = BindingContext as UnesiNapomenuView;
	        this.OznaceniDogadaj = e.Item as NapomenaModel;
	        vm.PrikaziIliSakrijDetalje(OznaceniDogadaj);
        }


	    private void ObrisiNapomenu_Pressed(object sender, EventArgs e)
	    {
            //obrise ga nakon toga se source brise i ponovo se azurira
	        App.DatabaseController.ObrisiNapomenu(OznaceniDogadaj.Id);
	        ElementListe.ItemsSource = null;
	        ElementListe.ItemsSource = App.DatabaseController.DohvatiSveNapomene();
        }

	    private async void UrediDogadaj_OnPressed(object sender, EventArgs e)
	    {
            //MainPage = new NavigationPage(new UnesiNapomenuView());
            //i predajemo oznaceni item postavljamo polja na ta i zovemo insert app....

	        await Navigation.PushAsync(new UnesiNapomenuView(this.OznaceniDogadaj));
        }
    }
}