using System.Threading.Tasks;
using Module5_HW1.Models;

namespace Module5_HW1.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<Collection<User>> GetUsersByPage(int page);
        Task<Collection<User>> GetUsersByDelay(int delay);
        Task<Employee> CreateUserEmployee(string name, string job);
        Task<Employee> UpdateUserEmployeeById(int id, string name, string job);
        Task<Employee> ModifyUserEmployeeById(int id, string name, string job);
        Task<VoidResult> RemoveUserEmployeeById(int id);
    }
}
