using System.Threading.Tasks;
using Module5_HW1.Models;

namespace Module5_HW1.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login(string login, string password);
        Task<RegisterResult> Register(string login, string password);
    }
}
