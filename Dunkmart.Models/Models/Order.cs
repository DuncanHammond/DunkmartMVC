using Dunkmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunkmart.Models
{
    public class Order : IOrder
    {
        private int _orderID;
        public int OrderID { get => _orderID; set => _orderID = value; }
        private int _loyaltyID;
        public int LoyaltyID { get => _loyaltyID; set => _loyaltyID = value; }
        private int _transactionID;
        public int TransactionID { get => _transactionID; set => _transactionID = value; }
        private DateTime _pickUpTime;
        public DateTime PickUpTime { get => _pickUpTime; set => _pickUpTime = value; }
        
    }
}
