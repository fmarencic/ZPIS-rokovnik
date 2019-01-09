using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views
{
    public class UnesiNapomenuViewModel : BaseViewModel
    {
        public ICommand UnesiNapomenuCommand { get; private set; }

        public UnesiNapomenuViewModel()
        {
            UnesiNapomenuCommand = new Command(UnesiNapomenu);
        }

        private void UnesiNapomenu()
        {

        }

    }
}
