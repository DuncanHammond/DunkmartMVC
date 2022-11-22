using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dunkmart.Data;
using Dunkmart.Models;

namespace Dunkmart.Services
{
    public class TransactionService : ITransactionService  // HAVEN'T FINISHED CHANGING TABLE CONTENTS YET!
    {
        private readonly ApplicationDbContext _context;
        public async Task<bool> CreateAsync(ITransaction transaction)
        {
            var entity = new TransactionEntity
            {
                TransactionID = transaction.TransactionID,
                LoyaltyID = transaction.LoyaltyID,
                NumberOfItems = transaction.NumberOfItems,
                LicenseRequired = transaction.LicenseRequired,
                TotalCost = transaction.TotalCost,
                ItemsInCart = transaction.ItemsInCart
            };
            _context.Transaction.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<ITransaction>> GetAsync()
        {
            var query = _context.Transaction.Select(entity => new Transaction
            {
                TransactionID = entity.TransactionID,
                LoyaltyID = entity.LoyaltyID,
                NumberOfItems = entity.NumberOfItems,
                LicenseRequired = entity.LicenseRequired,
                TotalCost = entity.TotalCost,
                ItemsInCart = entity.ItemsInCart
            });
            return await query.ToListAsync();
        }

        public async Task<ITransaction> GetAsync(int id)
        {
            var query = await _context.Transaction.FirstOrDefaultAsync(p => p.LoyaltyID == id);
            var transactionDetail = new Transaction
            {
                TransactionID = query.TransactionID,
                LoyaltyID = query.LoyaltyID,
                NumberOfItems = query.NumberOfItems,
                LicenseRequired = query.LicenseRequired,
                TotalCost = query.TotalCost,
                ItemsInCart = query.ItemsInCart
            };

            return transactionDetail;
        }

        public async Task<bool> EditAsync(ITransaction transaction)
        {
            if (transaction == null)
                return false;
            var transactionEdit = await _context.Transaction.FindAsync(transaction);
            transactionEdit.TransactionID = transaction.TransactionID;
            transactionEdit.LoyaltyID = transaction.LoyaltyID;
            transactionEdit.NumberOfItems = transaction.NumberOfItems;
            transactionEdit.LicenseRequired = transaction.LicenseRequired;
            transactionEdit.TotalCost = transaction.TotalCost;
            transactionEdit.ItemsInCart = transaction.ItemsInCart;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transactionDelete = await _context.Transaction.FindAsync(id);
            if (transactionDelete == null)
                return false;
            _context.Transaction.Remove(transactionDelete);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
