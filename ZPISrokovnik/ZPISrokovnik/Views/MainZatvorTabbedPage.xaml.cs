using UserTypeInterface;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ZPISrokovnik.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
<<<<<<< HEAD:ZPISrokovnik/ZPISrokovnik/Views/MainZatvorTabbedPage.xaml.cs
    public partial class MainZatvorTabbedPage : Xamarin.Forms.TabbedPage
=======
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage, ITabbedPageView
>>>>>>> fc93e03b889015886f42983f12231d01f8a337e7:ZPISrokovnik/ZPISrokovnik/Views/MainTabbedPage.xaml.cs
    {
        public MainZatvorTabbedPage()
        {
            UcitajView();
        }

        public MainZatvorTabbedPage(object o)
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