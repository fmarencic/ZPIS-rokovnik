using System.Threading.Tasks;
using UserTypeInterface;
using Xamarin.Forms;

namespace ZPISrokovnik.Utils
{
    public interface ILoginPageService : IPageService
    {
        Task PushAfterLogin(Page page);
        Task PushAfterLogin(ITabbedPageView page);

    }
}
