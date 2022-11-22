using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunkmart.Models
{
    public class Profile : IProfile
    {
        private int _loyaltyID;
        public int LoyaltyID { get => _loyaltyID; set => _loyaltyID = value; }
        private int _userID;
        public int UserID { get => _userID; set => _userID = value; }
        private bool _allergies;
        public bool Allergies { get => _allergies; set => _allergies = value; }
        private int _legalAge;
        public int LegalAge { get => _legalAge; set => _legalAge = value; }
        private bool _loyaltyMember;
        public bool LoyaltyMember { get => _loyaltyMember; set => _loyaltyMember = value; }
    }
}
