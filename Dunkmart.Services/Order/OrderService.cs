using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dunkmart.Data;
using Dunkmart.Models;

namespace Dunkmart.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(IOrder order)
        {
            var entity = new OrderEntity
            {
                OrderID = order.OrderID,
                LoyaltyID = order.LoyaltyID,
                TransactionID = order.TransactionID,
                PickUpTime = order.PickUpTime,
            };
            _context.Order.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<IOrder>> GetAsync()
        {
            var query = _context.Order.Select(entity => new Order
            {
                OrderID = entity.OrderID,
                LoyaltyID = entity.LoyaltyID,
                TransactionID = entity.TransactionID,
                PickUpTime = entity.PickUpTime,
            });
            return await query.ToListAsync();
        }

        public async Task<IOrder> GetAsync(int id)
        {
            var query = await _context.Order.FirstOrDefaultAsync(p => p.LoyaltyID == id);
            var orderDetail = new Order
            {
                OrderID = query.OrderID,
                LoyaltyID = query.LoyaltyID,
                TransactionID = query.TransactionID,
                PickUpTime = query.PickUpTime,
            };

            return orderDetail;
        }

        public async Task<bool> EditAsync(IOrder order)
        {
            if (order == null)
                return false;
            var orderEdit = await _context.Order.FindAsync(order);
            orderEdit.OrderID = order.OrderID;
            orderEdit.LoyaltyID = order.LoyaltyID;
            orderEdit.TransactionID = order.TransactionID;
            orderEdit.PickUpTime = order.PickUpTime;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderDelete = await _context.Order.FindAsync(id);
            if (orderDelete == null)
                return false;
            _context.Order.Remove(orderDelete);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
