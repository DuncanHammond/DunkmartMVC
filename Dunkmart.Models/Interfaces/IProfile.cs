using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunkmart.Models
{
    public interface IProfile
    {
        public int LoyaltyID { get; set; }
        public int UserID { get; set; }
        public bool Allergies { get; set; }
        public int LegalAge { get; set; }
        public bool LoyaltyMember { get; set; }
    }
}
