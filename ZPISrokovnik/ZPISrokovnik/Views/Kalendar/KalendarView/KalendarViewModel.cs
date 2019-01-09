using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;

namespace ZPISrokovnik.Views
{
    public class KalendarViewModel : BaseViewModel
    {
        public ICommand UnesiNapomenuCommand { get; private set; }
        public ICommand UrediNapomenuCommand { get; private set; }
        public ICommand ObrisiNapomenuCommand { get; private set; }

        private Napomena SelektiranaNapomena;

        public Napomena ElementListeNapomena
        {
            get { return SelektiranaNapomena; }
            set
            {
                if (SelektiranaNapomena != value)
                {
                    SelektiranaNapomena = value;
                    OnPropertyChanged("ItemSelected");
                    /*
                     * And if you want to perform any additional
                     * functionality like navigating to detail page,
                     * you can do it from the set property after
                     * OnPropertyChanged statement is executed.
                     */
                }
            }
        }
        
        public KalendarViewModel(IPageService page)
        {
            UnesiNapomenuCommand = new Command(UnesiNapomenu);
            UrediNapomenuCommand = new Command(UrediNapomenu);
            ObrisiNapomenuCommand = new Command(ObrisiNapomenu);
        }

        //CommandParameter="{Binding Source={x:Reference entry}, Path=Text}"
        private void UnesiNapomenu()
        {
            //await Navigation.PushAsync(new UnesiNapomenuView());
        }

        private void UrediNapomenu()
        {

        }

        private void ObrisiNapomenu()
        {

        }


    }
}
