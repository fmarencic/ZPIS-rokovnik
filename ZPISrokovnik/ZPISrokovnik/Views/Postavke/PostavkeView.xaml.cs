﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views.Postavke
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostavkeView : ContentPage
    {
        public PostavkeView()
        {
            InitializeComponent();
            this.BindingContext = new PostavkeViewModel();
        }
    }
}