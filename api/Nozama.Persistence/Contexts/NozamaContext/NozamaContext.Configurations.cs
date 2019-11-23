using Microsoft.EntityFrameworkCore;
using Nozama.Persistence.Configurations.Aggregates;
using Nozama.Persistence.Configurations.Entities;

namespace Nozama.Persistence.Contexts
{
    public partial class NozamaContext : DbContext
    {
        public NozamaContext(DbContextOptions<NozamaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new OfferConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
        }
    }
}