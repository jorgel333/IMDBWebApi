using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);

            builder.Property(a => a.UserName).IsRequired().HasMaxLength(24);

            builder.Property(a => a.Email).IsRequired().HasMaxLength(250);

            builder.Property(a => a.Password).IsRequired().HasMaxLength(42);

            builder.Property(a => a.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}
