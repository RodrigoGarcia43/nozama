using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nozama.Domain.Models.Aggregates;

namespace Nozama.Persistence.Configurations.Aggregates
{
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.SellerId).IsRequired();
            builder.Property(o => o.ProductId).IsRequired();
            builder.Property(o => o.Amount).IsRequired();
            builder.Property(o => o.Value).IsRequired();

            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Seller)
            .WithMany(s => s.Offers)
            .HasForeignKey(o => o.SellerId);

            builder.HasOne(o => o.Product)
            .WithMany(p => p.Offers)
            .HasForeignKey(o => o.ProductId);
        }
    }
}