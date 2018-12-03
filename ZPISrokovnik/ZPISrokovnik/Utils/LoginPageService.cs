using System.Threading.Tasks;
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
    }
}
