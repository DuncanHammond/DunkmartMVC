using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Models;

namespace Dunkmart.Services
{
    public interface IOrderService
    {
        Task<bool> CreateAsync(IOrder order);
        Task<IEnumerable<IOrder>> GetAsync();
        Task<IOrder> GetAsync(int id);
        Task<bool> EditAsync(IOrder order);
        Task<bool> DeleteAsync(int id);
    }
}
