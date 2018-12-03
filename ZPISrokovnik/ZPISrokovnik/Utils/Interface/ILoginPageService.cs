using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZPISrokovnik.Utils
{
    public interface ILoginPageService : IPageService
    {
        Task PushAfterLogin(Page page);
    }
}
