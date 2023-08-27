using IMDBWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDBWebApi.Infra.Database.EntitiesConfiguration
{
    public class CastDirectMoviesConfiguration : IEntityTypeConfiguration<CastDirectMovies>
    {
        public void Configure(EntityTypeBuilder<CastDirectMovies> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.CastDirector).WithMany(d => d.DirectedMovies).HasForeignKey(d => d.CastDirectorId);

            builder.HasOne(d => d.MovieDirect).WithMany(d => d.DirectorMovies).HasForeignKey(d => d.MovieDirectId);
        }
    }
}
