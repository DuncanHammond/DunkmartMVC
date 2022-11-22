using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Models;

namespace Dunkmart.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateAsync(ITransaction transaction);
        Task<IEnumerable<ITransaction>> GetAsync();
        Task<ITransaction> GetAsync(int id);
        Task<bool> EditAsync(ITransaction transaction);
        Task<bool> DeleteAsync(int id);
    }
}
