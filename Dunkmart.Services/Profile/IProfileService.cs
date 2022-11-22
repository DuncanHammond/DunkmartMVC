using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Models;

namespace Dunkmart.Services
{
    public interface IProfileService
    {
        Task<bool> CreateAsync(IProfile profile);
        Task<IEnumerable<IProfile>> GetAsync();
        Task<IProfile> GetAsync(int id);
        Task<bool> EditAsync(IProfile profile);
        Task<bool> DeleteAsync(int id);
    }
}
