using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auction.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        private ICollection<AuctionList> AuctionList { get; set; }
    }
}
