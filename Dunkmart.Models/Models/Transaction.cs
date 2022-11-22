using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Data;

namespace Dunkmart.Models
{
    public class Transaction : ITransaction
    {
        private int _transactionID;
        public int TransactionID { get => _transactionID; set => _transactionID = value; }
        private int _numberOfItems;
        public int NumberOfItems { get => _numberOfItems; set => _numberOfItems = value; }
        private decimal _totalCost;
        public decimal TotalCost { get => _totalCost; set => _totalCost = value; }
        private bool _licenseRequired;
        public bool LicenseRequired { get => _licenseRequired; set => _licenseRequired = value; }
        private Array _itemsInCart;
        public Array ItemsInCart { get => _itemsInCart; set => _itemsInCart = value; }
        private int _loyaltyID;
        public int LoyaltyID { get => _loyaltyID; set => _loyaltyID = value; }

    }
}
