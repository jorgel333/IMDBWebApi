using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasIndex(c => c.UserName).IsUnique();

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);

            builder.Property(a => a.UserName).IsRequired().HasMaxLength(24);

            builder.Property(a => a.Email).IsRequired().HasMaxLength(250);

            builder.Property(a => a.PasswordHashSalt).IsRequired().HasMaxLength(32);

            builder.Property(a => a.PasswordSalt).IsRequired().HasMaxLength(12);

            builder.Property(a => a.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
