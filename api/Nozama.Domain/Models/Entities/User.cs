using System.Collections.Generic;
using Nozama.Domain.Models.Aggregates;

namespace Nozama.Domain.Models.Entities
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public long Balance { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Sale> Buys { get; set; }
    }
}