using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dunkmart.Data;
using Dunkmart.Models;
using System.Reflection.Metadata.Ecma335;

namespace Dunkmart.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(IProfile profile)
        {
            var entity = new ProfileEntity
            {
                LoyaltyID = profile.LoyaltyID,
                UserID = profile.UserID,
                Allergies = profile.Allergies,
                LegalAge = profile.LegalAge,
                LoyaltyMember = profile.LoyaltyMember
            };
            _context.Profile.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<IProfile>> GetAsync()
        {
            var query = _context.Profile.Select(entity => new Profile
            {
                LoyaltyID = entity.LoyaltyID,
                UserID = entity.UserID,
                LegalAge = entity.LegalAge,
                Allergies = entity.Allergies,
                LoyaltyMember = entity.LoyaltyMember
            });
            return await query.ToListAsync();
        }

        public async Task<IProfile> GetAsync(int id)
        {
            var query = await _context.Profile.FirstOrDefaultAsync(p => p.LoyaltyID == id);
            var profileDetail = new Profile
            {
                LoyaltyID = query.LoyaltyID,
                UserID = query.UserID,
                LegalAge = query.LegalAge,
                Allergies = query.Allergies,
                LoyaltyMember = query.Allergies
            };
            
            return profileDetail;
        }

        public async Task<bool> EditAsync(IProfile profile)
        {
            if (profile == null)
                return false;
            var profileEdit = await _context.Profile.FindAsync(profile);
            profileEdit.LoyaltyID = profile.LoyaltyID;
            profileEdit.UserID = profile.UserID;
            profileEdit.LegalAge = profile.LegalAge;
            profileEdit.Allergies = profile.Allergies;
            profileEdit.LoyaltyMember = profile.LoyaltyMember;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profileDelete = await _context.Profile.FindAsync(id);
            if (profileDelete == null)
                return false;
            _context.Profile.Remove(profileDelete);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
