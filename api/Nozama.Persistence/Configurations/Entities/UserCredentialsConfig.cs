using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nozama.Domain.Models.Entities;

namespace Nozama.Persistence.Configurations.Entities
{
    public class UserCredentialsConfig : IEntityTypeConfiguration<UserCredentials>
    {
        public void Configure(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Username);
        }
    }
}