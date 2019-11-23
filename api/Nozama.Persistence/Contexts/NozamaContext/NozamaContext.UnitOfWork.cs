using Microsoft.EntityFrameworkCore;
using Nozama.Domain.Models.Aggregates;
using Nozama.Domain.Models.Entities;

namespace Nozama.Persistence.Contexts
{
    public partial class NozamaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}