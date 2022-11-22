using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunkmart.Models
{
    public interface IOrder
    {
        public int OrderID { get; set; }
        public int LoyaltyID { get; set; }
        public int TransactionID { get; set; }
        public DateTime PickUpTime { get; set; }
    }
}
