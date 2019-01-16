using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;

namespace ZPISrokovnik.Views
{
    public class UnesiNapomenuViewModel : BaseViewModel
    {
        public ICommand UnesiNapomenuCommand { get; private set; }
        public Napomena Napomena { get; set; }

        public UnesiNapomenuViewModel()
        {
            this.Napomena = new Napomena();
            UnesiNapomenuCommand = new Command(UnesiNapomenu);
        }

        public UnesiNapomenuViewModel(Napomena napomena)
        {
            this.Napomena = napomena;
            UnesiNapomenuCommand = new Command(UnesiNapomenu);
        }

        private void UnesiNapomenu()
        {
            App.DatabaseController.SpremiNapomenu(this.Napomena);
        }

    }
}
