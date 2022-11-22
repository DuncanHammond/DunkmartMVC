using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dunkmart.Data;
using Dunkmart.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dunkmart.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(IItem item)
        {
            var entity = new ItemEntity
            {
                ItemID = item.ItemID,
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice,
                ItemStock = item.ItemStock,
                Damaged = item.Damaged,
                SellByDate = item.SellByDate,
                AisleLocation = item.AisleLocation,
                Type = item.Type
                
            };
            _context.Item.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<IItem>> GetAsync()
        {
            var query = _context.Item.Select(entity => new Item
            {
                ItemID = entity.ItemID,
                ItemName = entity.ItemName,
                ItemPrice = entity.ItemPrice,
                ItemStock = entity.ItemStock,
                Damaged = entity.Damaged,
                SellByDate = entity.SellByDate,
                AisleLocation = entity.AisleLocation,
                Type = entity.Type
            });
            return await query.ToListAsync();
        }

        public async Task<IItem> GetAsync(int id)
        {
            var query = await _context.Item.FirstOrDefaultAsync(i => i.ItemID == id);
            var itemDetail = new Item
            {
                ItemID = query.ItemID,
                ItemName = query.ItemName,
                ItemPrice = query.ItemPrice,
                ItemStock = query.ItemStock,
                Damaged = query.Damaged,
                SellByDate = query.SellByDate,
                AisleLocation = query.AisleLocation,
                Type = query.Type
            };

            return itemDetail;
        }

        public async Task<bool> EditAsync(IItem item)
        {
            if (item == null)
                return false;
            var itemEdit = await _context.Item.FindAsync(item);

            itemEdit.ItemID = item.ItemID;
            itemEdit.ItemName = item.ItemName;
            itemEdit.ItemPrice = item.ItemPrice;
            itemEdit.ItemStock = item.ItemStock;
            itemEdit.Damaged = item.Damaged;
            itemEdit.SellByDate = item.SellByDate;
            itemEdit.AisleLocation = item.AisleLocation;
            itemEdit.Type = item.Type;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var itemDelete = await _context.Item.FindAsync(id);
            if (itemDelete == null)
                return false;
            _context.Item.Remove(itemDelete);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
