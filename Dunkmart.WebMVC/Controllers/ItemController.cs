using Dunkmart.Data;
using Dunkmart.Models;
using Dunkmart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunkmart.WebMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ApplicationDbContext _context;

        public ItemController(IItemService itemService, ApplicationDbContext context)
        {
            _itemService = itemService;
            _context = context;
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ItemName,ItemPrice,ItemStock,SellByDate,Damaged,AisleLocation,Type")] Item model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Item
                {
                    ItemID = model.ItemID,
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice,
                    ItemStock = model.ItemStock,
                    SellByDate = model.SellByDate,
                    Damaged = model.Damaged,
                    AisleLocation = model.AisleLocation,
                    Type = model.Type
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //Index
        public async Task<IActionResult> Index()
        {
            var items = await _context
              .Item
              .Select(i => new Item
              {
                  ItemID = i.ItemID,
                  ItemName = i.ItemName,
                  ItemStock = i.ItemStock,
                  ItemPrice = i.ItemPrice,
                  SellByDate = i.SellByDate,
                  AisleLocation = i.AisleLocation,
                  Damaged = i.Damaged,
                  Type = i.Type
              })
              .ToListAsync();
            return View(items);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Select(i => new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemStock = i.ItemStock,
                    ItemPrice = i.ItemPrice,
                    SellByDate = i.SellByDate,
                    AisleLocation = i.AisleLocation,
                    Damaged = i.Damaged,
                    Type = i.Type
                })
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context
                .Item
                .Select(i => new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemStock = i.ItemStock,
                    ItemPrice = i.ItemPrice,
                    SellByDate = i.SellByDate,
                    AisleLocation = i.AisleLocation,
                    Damaged = i.Damaged,
                    Type = i.Type
                })
                .FirstOrDefaultAsync(i => i.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemName,ItemPrice,ItemStock,SellByDate,Damaged,AisleLocation,Type")] Item model)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                item.ItemName = model.ItemName;
                item.ItemPrice = model.ItemPrice;
                item.ItemStock = model.ItemStock;
                item.ItemPrice = model.ItemPrice;
                item.SellByDate = model.SellByDate;
                item.AisleLocation = model.AisleLocation;
                item.Damaged = model.Damaged;
                item.Type = model.Type;
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(item.ItemID))
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
            return View(item);
        }



        // Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context
                .Item
                .Select(i => new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemStock = i.ItemStock,
                    ItemPrice = i.ItemPrice,
                    SellByDate = i.SellByDate,
                    AisleLocation = i.AisleLocation,
                    Damaged = i.Damaged,
                    Type = i.Type
                })
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Item?.Any(e => e.ItemID == id)).GetValueOrDefault();
        }

       
    }
}


