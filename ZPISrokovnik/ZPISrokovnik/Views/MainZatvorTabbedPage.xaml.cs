using UserTypeInterface;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainZatvorTabbedPage : Xamarin.Forms.TabbedPage, ITabbedPageView

    {
        public MainZatvorTabbedPage()
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