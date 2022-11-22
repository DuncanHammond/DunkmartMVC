using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunkmart.Models
{
    public interface ITransaction
    {
        public int TransactionID { get; set; }
        public int LoyaltyID { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalCost { get; set; }
        public bool LicenseRequired { get; set; }
        public Array ItemsInCart { get; set; }
    }
}
