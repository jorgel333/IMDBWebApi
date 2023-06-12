using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(120);
            
            builder.Property(m => m.Description).IsRequired().HasMaxLength(500);

            builder.Property(m => m.Duration).HasMaxLength(4);
            
            builder.Property(m => m.TotalVotes).IsRequired().HasDefaultValue(0);

            builder.Property(m => m.RatingAverage).IsRequired().HasPrecision(4, 2).HasDefaultValue(0);

            builder.Property(m => m.Image).HasMaxLength(250);

            builder.HasMany(m => m.Assessments).WithOne(m => m.Movie).HasForeignKey(m => m.MovieId);

            builder.HasMany(m => m.ActorMovies).WithOne(m => m.MovieAct).HasForeignKey(m => m.MovieActId);

            builder.HasMany(m => m.DirectorMovies).WithOne(m => m.MovieDirect).HasForeignKey(m => m.MovieDirectId);

            builder.HasMany(m => m.GenresMovies).WithOne(m => m.Movie).HasForeignKey(m => m.MovieId);
        }
    }
}
