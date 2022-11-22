using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Data;

namespace Dunkmart.Models
{
    public class Item : IItem
    {
        private int _itemID;
        public int ItemID { get => _itemID; set => _itemID = value; }
        private string _itemName;
        public string ItemName { get => _itemName; set => _itemName = value; }
        private decimal _itemPrice;
        public decimal ItemPrice { get => _itemPrice; set => _itemPrice = value; }
        private DateTime _sellByDate;
        public DateTime SellByDate { get => _sellByDate; set => _sellByDate = value; }
        private bool _damaged;
        public bool Damaged { get => _damaged; set => _damaged = value; }
        private int _aisleLocation;
        public int AisleLocation { get => _aisleLocation; set => _aisleLocation = value; }
        private ItemType _type;
        public ItemType Type { get => _type; set => _type = value; }
        private int _itemStock;
        public int ItemStock { get => _itemStock; set => _itemStock = value; }
    }
}
