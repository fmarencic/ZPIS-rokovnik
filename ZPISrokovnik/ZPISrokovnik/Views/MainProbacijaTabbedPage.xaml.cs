using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTypeInterface;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainProbacijaTabbedPage : Xamarin.Forms.TabbedPage, ITabbedPageView
    {
        public MainProbacijaTabbedPage ()
        {
            UcitajView();
        }

        public void UcitajView()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}