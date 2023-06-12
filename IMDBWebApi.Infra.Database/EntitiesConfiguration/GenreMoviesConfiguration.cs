using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class GenreMoviesConfiguration : IEntityTypeConfiguration<GenreMovies>
    {
        public void Configure(EntityTypeBuilder<GenreMovies> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Genre).WithMany(g => g.GenreMovies).HasForeignKey(g => g.GenreId);

            builder.HasOne(g => g.Movie).WithMany(g => g.GenresMovies).HasForeignKey(g => g.MovieId);
        }
    }
}
