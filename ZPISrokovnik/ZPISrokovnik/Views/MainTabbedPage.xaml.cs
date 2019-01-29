using UserTypeInterface;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage, ITabbedPageView
    {
        public MainTabbedPage()
        {
            UcitajView();
        }

        public MainTabbedPage(object o)
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