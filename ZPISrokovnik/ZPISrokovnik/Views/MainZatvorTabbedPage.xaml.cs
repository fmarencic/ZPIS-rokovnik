using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainZatvorTabbedPage : Xamarin.Forms.TabbedPage
    {
        public MainZatvorTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        public MainZatvorTabbedPage(object o)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

        }
    }
}