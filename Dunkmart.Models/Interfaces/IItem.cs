using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunkmart.Data;

namespace Dunkmart.Models
{
    public interface IItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemStock { get; set; }
        public decimal ItemPrice { get; set; }
        public DateTime SellByDate { get; set; }
        public bool Damaged { get; set; }
        public int AisleLocation { get; set; }
        public ItemType Type { get; set; }
    }
    

}

