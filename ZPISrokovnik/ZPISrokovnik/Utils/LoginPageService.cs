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
            if (typeof(MainZatvorTabbedPage) == view.GetType())
            {
                Application.Current.MainPage.Navigation.InsertPageBefore((MainZatvorTabbedPage)view, loginView);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            if (typeof(MainProbacijaTabbedPage) == view.GetType())
            {
                Application.Current.MainPage.Navigation.InsertPageBefore((MainProbacijaTabbedPage)view, loginView);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
