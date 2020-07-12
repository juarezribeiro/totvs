using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double InitialValue { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool Status { get; set; }
        public ICollection<AuctionList> AuctionList { get; set; }
    }
}
