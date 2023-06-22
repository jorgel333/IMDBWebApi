using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class CommonUserConfiguration : IEntityTypeConfiguration<CommonUser>
    {
        public void Configure(EntityTypeBuilder<CommonUser> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.UserName).IsUnique();

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.Property(c => c.UserName).IsRequired().HasMaxLength(24);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(250);

            builder.Property(c => c.PasswordHashSalt).IsRequired().HasMaxLength(32);

            builder.Property(c => c.PasswordSalt).IsRequired().HasMaxLength(12);

            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasMany(c => c.Assessments).WithOne(c => c.CommonUser).HasForeignKey(c => c.CommonUserId);
        }
    }
}
