using Dunkmart.Models;

namespace Dunkmart.Services
{
    public interface IItemService
    {
        Task<bool> CreateAsync(IItem item);
        Task<IEnumerable<IItem>> GetAsync();
        Task<IItem> GetAsync(int id);
        Task<bool> EditAsync(IItem item);
        Task<bool> DeleteAsync(int id);
    }
}
