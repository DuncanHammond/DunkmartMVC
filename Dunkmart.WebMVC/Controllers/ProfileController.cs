using Dunkmart.Data;
using Dunkmart.Models;
using Dunkmart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunkmart.WebMVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly ApplicationDbContext _context;

        public ProfileController(IProfileService profileService, ApplicationDbContext context)
        {
            _profileService = profileService;
            _context = context;
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoyaltyID,UserID,Allergies,LegalAge,LoyaltyMember")] Profile model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Profile
                {
                    LoyaltyID = model.LoyaltyID,
                    UserID = model.UserID,
                    Allergies = model.Allergies,
                    LegalAge = model.LegalAge,
                    LoyaltyMember = model.LoyaltyMember
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //Index
        public async Task<IActionResult> Index()
        {
            var profiles = await _context
              .Profile
              .Select(p => new Profile
              {
                  LoyaltyID = p.LoyaltyID,
                  UserID = p.UserID,
                  Allergies = p.Allergies,
                  LegalAge = p.LegalAge,
                  LoyaltyMember = p.LoyaltyMember
              })
              .ToListAsync();
            return View(profiles);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .Select(p => new Profile
                {
                    LoyaltyID = p.LoyaltyID,
                    UserID = p.UserID,
                    Allergies = p.Allergies,
                    LegalAge = p.LegalAge,
                    LoyaltyMember = p.LoyaltyMember
                })
                .FirstOrDefaultAsync(m => m.LoyaltyID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context
                .Profile
                .Select(p => new Profile
                {
                    LoyaltyID = p.LoyaltyID,
                    UserID = p.UserID,
                    Allergies = p.Allergies,
                    LegalAge = p.LegalAge,
                    LoyaltyMember = p.LoyaltyMember
                })
                .FirstOrDefaultAsync(p => p.LoyaltyID == id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoyaltyID,UserID,Allergies,LegalAge,LoyaltyMember")] Profile model)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                profile.LoyaltyID = model.LoyaltyID;
                profile.UserID = model.UserID;
                profile.Allergies = model.Allergies;
                profile.LegalAge = model.LegalAge;
                profile.LoyaltyMember = model.LoyaltyMember;
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(profile.LoyaltyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }



        // Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context
                .Profile
                .Select(p => new Profile
                {
                    LoyaltyID = p.LoyaltyID,
                    UserID = p.UserID,
                    Allergies = p.Allergies,
                    LegalAge = p.LegalAge,
                    LoyaltyMember = p.LoyaltyMember
                })
                .FirstOrDefaultAsync(m => m.LoyaltyID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Profile?.Any(e => e.LoyaltyID == id)).GetValueOrDefault();
        }


    }
}


