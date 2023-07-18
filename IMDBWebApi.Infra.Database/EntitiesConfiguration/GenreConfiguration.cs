using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasIndex(g => g.Name).IsUnique();

            builder.HasMany(g => g.GenreMovies).WithOne(g => g.Genre).HasForeignKey(g => g.GenreId);
        }
    }
}
