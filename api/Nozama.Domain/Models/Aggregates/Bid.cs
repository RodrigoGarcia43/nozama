using Nozama.Domain.Models.Entities;

namespace Nozama.Domain.Models.Aggregates
{
    public class Bid
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string AuctionId { get; set; }
        public Auction Auction { get; set; }

        public int Value { get; set; }
    }
}