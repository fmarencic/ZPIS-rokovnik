using System.Threading.Tasks;
using UserTypeInterface;
using Xamarin.Forms;
using ZPISrokovnik.Views;

namespace ZPISrokovnik.Utils
{
    public class LoginPageService : PageService, ILoginPageService
    {
        public LoginView loginView;

        public LoginPageService(LoginView loginView)
        {
            this.loginView = loginView;
        }

        public async Task PushAfterLogin(Page page)
        {
            Application.Current.MainPage.Navigation.InsertPageBefore(page, loginView);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PushAfterLogin(ITabbedPageView view)
        {
            if (typeof(MainTabbedPage) == view.GetType())
            {
                Application.Current.MainPage.Navigation.InsertPageBefore((MainTabbedPage)view, loginView);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
