using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nozama.Domain.Models.Aggregates;

namespace Nozama.Persistence.Configurations.Aggregates
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.SellerId).IsRequired();
            builder.Property(s => s.ProductId).IsRequired();
            builder.Property(s => s.BuyerId).IsRequired();
            builder.Property(s => s.Value).IsRequired();

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Seller)
            .WithMany(s => s.Sales)
            .HasForeignKey(s => s.SellerId);

            builder.HasOne(s => s.Buyer)
            .WithMany(b => b.Sales)
            .HasForeignKey(s => s.BuyerId);

            builder.HasOne(s => s.Product)
            .WithMany(p => p.Sales)
            .HasForeignKey(s => s.ProductId);
        }
    }
}