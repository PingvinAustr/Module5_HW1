using System.Threading.Tasks;
using Module5_HW1.Models;

namespace Module5_HW1.Services.Interfaces
{
    public interface IResourceService
    {
        Task<Resource> GetResourceById(int id);
        Task<Collection<Resource>> GetAllResources();
    }
}
