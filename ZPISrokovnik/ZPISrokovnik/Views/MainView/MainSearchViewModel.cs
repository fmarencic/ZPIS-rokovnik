using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
	public class MainSearchViewModel : BaseViewModel
	{
		public MainSearchViewModel ()
		{

		}

        string caption = "Zatvor u Zagrebu";

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                OnPropertyChanged();
            }
        }
    }
}