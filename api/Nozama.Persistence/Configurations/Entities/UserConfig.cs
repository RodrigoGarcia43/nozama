using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nozama.Domain.Models.Entities;

namespace Nozama.Persistence.Configurations.Entities
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.CredentialsId).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Balance).IsRequired();

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Credentials)
            .WithOne(uc => uc.User)
            .HasForeignKey<User>(u => u.CredentialsId);
        }
    }
}