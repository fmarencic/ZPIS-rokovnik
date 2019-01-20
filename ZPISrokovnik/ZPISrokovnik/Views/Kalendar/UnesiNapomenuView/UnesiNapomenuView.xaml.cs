using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

//!
namespace ZPISrokovnik.Views.Kalendar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UnesiNapomenuView : ContentPage
	{
		public UnesiNapomenuView ()
		{
			InitializeComponent ();
            this.BindingContext = new UnesiNapomenuViewModel();
		}

	    public UnesiNapomenuView(Napomena napomena)
	    {
	        InitializeComponent();
	        this.BindingContext = new UnesiNapomenuViewModel(napomena);
	    }
    }
}