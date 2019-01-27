using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Util;
using Plugin.LocalNotifications;
using Syncfusion.SfSchedule.XForms;
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
	    private void Napomena_OnMonthInlineAppointmentTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
	    {
	        var napomena = (e.Appointment as Napomena);
            if (napomena != null)
            {
                var viewModel = this.BindingContext as KalendarViewModel;
                viewModel?.PrikaziNapomenuCommand.Execute(napomena);
            }
        }
	    protected override void OnAppearing()
	    {
	        var viewModel = this.BindingContext as KalendarViewModel;
	        viewModel?.AzurirajCommand.Execute(null);
        }
	}
}