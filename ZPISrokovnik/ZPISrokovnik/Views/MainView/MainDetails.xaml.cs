﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainDetails : ContentPage
	{
		public MainDetails ()
		{
			InitializeComponent ();
            BindingContext = new MainDetailsViewModel(new PageService());
		}
	}
}