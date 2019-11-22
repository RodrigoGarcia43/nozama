using System;
using System.Collections.Generic;

namespace Nozama.Domain.Models.Aggregates
{
    public class Auction : Offer
    {
        public ICollection<Bid> Bids { get; set; }

        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public Auction()
        {
            Bids = new HashSet<Bid>();
        }
    }
}