using System.Threading.Tasks;

namespace OnlineStore.Data.Auth
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
