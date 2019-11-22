using Nozama.Domain.Models.Entities;

namespace Nozama.Domain.Models.Aggregates
{
    public class Sale
    {
        public string Id { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string SellerId { get; set; }
        public User Seller { get; set; }

        public string BuyerId { get; set; }
        public User Buyer { get; set; }

        public int Value { get; set; }
    }
}