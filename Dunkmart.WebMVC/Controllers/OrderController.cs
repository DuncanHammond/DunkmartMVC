using Dunkmart.Data;
using Dunkmart.Models;
using Dunkmart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunkmart.WebMVC.Controllers
{
    public class IOrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _context;

        public IOrderController(IOrderService orderService, ApplicationDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,LoyaltyID,TransactionID,PickUpTime")] Order model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Order
                {
                    OrderID = model.OrderID,
                    LoyaltyID = model.LoyaltyID,
                    TransactionID = model.TransactionID,
                    PickUpTime = model.PickUpTime
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //Index
        public async Task<IActionResult> Index()
        {
            var orders = await _context
              .Order
              .Select(o => new Order
              {
                  OrderID = o.OrderID,
                  LoyaltyID = o.LoyaltyID,
                  TransactionID = o.TransactionID,
                  PickUpTime = o.PickUpTime
              })
              .ToListAsync();
            return View(orders);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Select(o => new Order
                {
                    OrderID = o.OrderID,
                    LoyaltyID = o.LoyaltyID,
                    TransactionID = o.TransactionID,
                    PickUpTime = o.PickUpTime
                })
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context
                .Order
                .Select(o => new Order
                {
                    OrderID = o.OrderID,
                    LoyaltyID = o.LoyaltyID,
                    TransactionID = o.TransactionID,
                    PickUpTime = o.PickUpTime
                })
                .FirstOrDefaultAsync(i => i.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,LoyaltyID,TransactionID,PickUpTime")] Order model)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                order.OrderID = model.OrderID;
                order.LoyaltyID = model.LoyaltyID;
                order.TransactionID = model.TransactionID;
                order.PickUpTime = model.PickUpTime;
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(order.OrderID))
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
            return View(order);
        }



        // Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context
                .Order
                .Select(o => new Order
                {
                    OrderID = o.OrderID,
                    LoyaltyID = o.LoyaltyID,
                    TransactionID = o.TransactionID,
                    PickUpTime = o.PickUpTime
                })
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
