using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Models
{
    public enum Condition
    {
        New, Used
    }

    public class AuctionList
    {
        public int AuctionListID { get; set; }
        public int UserID { get; set; }
        public int AuctionID { get; set; }
        public Condition Condition { get; set; }

        public User User { get; set; }
        public Auction Auction { get; set; }
    }
}
