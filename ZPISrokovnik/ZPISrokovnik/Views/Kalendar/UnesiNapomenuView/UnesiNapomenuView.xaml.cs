using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//!
namespace ZPISrokovnik.Views.Kalendar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UnesiNapomenuView : ContentPage
	{
	    public Napomena Napomena { get; set; }
		public UnesiNapomenuView ()
		{
			InitializeComponent ();
            this.BindingContext = new UnesiNapomenuView();
		}

	    public UnesiNapomenuView(Napomena napomena)
	    {
	        InitializeComponent();
	        this.Napomena = napomena;
	        NazivNapomene.Text = napomena.Naziv;
	        OdabraniDatum.Date = napomena.Datum;
	        OpisNapomene.Text = napomena.Opis;
	    }

	    private void UnesiNapomenu_Pressed(object sender, EventArgs e)
	    {
            //dohvatit vrijednosti i spremit u bazu
	        if (Napomena == null)
	        {
	            Napomena = new Napomena();
            }
	        
	        Napomena.Naziv = NazivNapomene.Text;
	        Napomena.Datum = OdabraniDatum.Date;
	        Napomena.Opis = OpisNapomene.Text;

            //sprema se u bazu
	        App.DatabaseController.SpremiNapomenu(Napomena);
            
	    }

	    public void PrikaziIliSakrijDetalje(Napomena dogadaj)
	    {
	        dogadaj.Vidljivo = true;
	    }
    }
}