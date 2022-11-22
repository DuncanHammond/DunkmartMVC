using Dunkmart.Data;
using Dunkmart.Models;
using Dunkmart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunkmart.WebMVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ApplicationDbContext _context;

        public TransactionController(ITransactionService transactionService, ApplicationDbContext context)
        {
            _transactionService = transactionService;
            _context = context;
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionID,LoyaltyID,NumberOfItems,TotalCost,LicenseRequired,ItemsInCart")] Transaction model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Transaction
                {
                    TransactionID = model.TransactionID,
                    LoyaltyID = model.LoyaltyID,
                    NumberOfItems = model.NumberOfItems,
                    TotalCost = model.TotalCost,
                    LicenseRequired = model.LicenseRequired,
                    ItemsInCart = model.ItemsInCart

                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //Index
        public async Task<IActionResult> Index()
        {
            var transactions = await _context
              .Transaction
              .Select(t => new Transaction
              {
                  TransactionID = t.TransactionID,
                  LoyaltyID = t.LoyaltyID,
                  NumberOfItems = t.NumberOfItems,
                  TotalCost = t.TotalCost,
                  LicenseRequired = t.LicenseRequired,
                  ItemsInCart = t.ItemsInCart
              })
              .ToListAsync();
            return View(transactions);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Select(t => new Transaction
                {
                    TransactionID = t.TransactionID,
                    LoyaltyID = t.LoyaltyID,
                    NumberOfItems = t.NumberOfItems,
                    TotalCost = t.TotalCost,
                    LicenseRequired = t.LicenseRequired,
                    ItemsInCart = t.ItemsInCart
                })
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context
                .Transaction
                .Select(t => new Transaction
                {
                    TransactionID = t.TransactionID,
                    LoyaltyID = t.LoyaltyID,
                    NumberOfItems = t.NumberOfItems,
                    TotalCost = t.TotalCost,
                    LicenseRequired = t.LicenseRequired,
                    ItemsInCart = t.ItemsInCart
                })
                .FirstOrDefaultAsync(i => i.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,LoyaltyID,NumberOfItems,TotalCost,LicenseRequired,ItemsInCart")] Transaction model)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                transaction.TransactionID = model.TransactionID;
                transaction.LoyaltyID = model.LoyaltyID;
                transaction.NumberOfItems = model.NumberOfItems;
                transaction.TotalCost = model.TotalCost;
                transaction.LicenseRequired = model.LicenseRequired;
                transaction.ItemsInCart = model.ItemsInCart;
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(transaction.TransactionID))
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
            return View(transaction);
        }



        // Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context
                .Transaction
                .Select(t => new Transaction
                {
                    TransactionID = t.TransactionID,
                    LoyaltyID = t.LoyaltyID,
                    NumberOfItems = t.NumberOfItems,
                    TotalCost = t.TotalCost,
                    LicenseRequired = t.LicenseRequired,
                    ItemsInCart = t.ItemsInCart
                })
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Transaction?.Any(e => e.TransactionID == id)).GetValueOrDefault();
        }


    }
}


