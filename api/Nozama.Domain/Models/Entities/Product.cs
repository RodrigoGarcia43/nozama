using System.Collections.Generic;
using Nozama.Domain.Models.Aggregates;

namespace Nozama.Domain.Models.Entities
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Auction> Auctions { get; set; }
    }
}